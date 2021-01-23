    public class Player : MonoBehaviour
    { 
        public float m_gravity=10f;          
        void Jump()
        {
            if (m_ch.isGrounded) //this is the point
            {
                m_Gravity = 10;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_Gravity = -8;
                }
            }
            else
            {
                m_Gravity += 10f * Time.deltaTime;
                if (m_Gravity >= 10) { m_Gravity = 10; }
            }
        }
    }
