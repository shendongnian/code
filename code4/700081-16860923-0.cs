    public class Time
    {
    
        [Timestamp]
        private byte[] _timestamp;
    
        [Timestamp]
        public byte[] Timestamp
        {
            get
            {
                return _timestamp == null ? new byte[0] : _timestamp;
            }
    
            set { _timestamp = value; }
        }
    }
