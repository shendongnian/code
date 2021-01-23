    public class User {
        private byte m_Status;
        private DateTime? m_DataStatus;
        public byte Status {
            get { return m_Status; }
            set { m_DataStatus = DateTime.Now; m_Status = value; }
        }
        public DateTime? DataStatus {
            get { return m_DataStatus; }
            set { m_DataStatus = value; }
        }
    }
