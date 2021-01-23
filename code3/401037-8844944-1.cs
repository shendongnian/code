        private int m_TestValue;
        public byte TestValue
        {
            get
            {
                if (m_TestValue < 0)
                {
                    return 0;
                }
                else
                {
                    return (byte)m_TestValue;
                }
            }
            set {
                m_TestValue = value;
            }
        }
