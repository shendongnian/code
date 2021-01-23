    public class Time
    {
        [Timestamp]
        private byte[] _timestamp;
        [Timestamp]
        public byte[] Timestamp
        {
            get
            {
                _timestamp = _timestamp == null ? new byte[0] : _timestamp;
                return _timestamp;
            }
            set { _timestamp = value; }
        }
    }
