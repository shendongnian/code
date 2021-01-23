    public class Time
    {
        [Timestamp]
        private Lazy<byte[]> _timestamp=new Lazy<byte[]>();
        [Timestamp]
        public Lazy<byte[]> Timestamp
        {
            get
            {
                return _timestamp;
            }
            set { _timestamp = value; }
        }
    }
