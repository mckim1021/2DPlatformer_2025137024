using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpForce = 1.5f;
    public Transform GroundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator pAni;
    private bool isGrounded;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAni = GetComponent<Animator>();
    }
    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            pAni.SetTrigger("JumpAction");
        }

        if (moveInput > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);

        if (moveInput < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

        if (isGrounded && Input.GetKey(KeyCode.A))
        {
            pAni.SetTrigger("RunAction");
        }

        if (isGrounded && Input.GetKey(KeyCode.D))
        {
            pAni.SetTrigger("RunAction");
        }
    }
}
