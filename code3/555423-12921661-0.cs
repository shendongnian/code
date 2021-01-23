    public class User
    {
        private byte _status;
        public byte Status
        {
            get { return _status; }
            set
            {
                _status = value;
                DataStatus = DateTime.Now;
            }
        }
        public DateTime? DataStatus { get; set; }
    }
