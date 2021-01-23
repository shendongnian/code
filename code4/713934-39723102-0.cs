        public float m_gravity=10f;          
        void Jump()
        {
            if (m_ch.isGrounded) //this is the point
            {
                m_gravity = 10;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_gravity = -8;
                }
            }
            else
            {
                m_gravity += 10f * Time.deltaTime;
                if (m_gravity >= 10) { m_gravity = 10; }
            }
        }
    }
