    class Lap
    {
        private DateTime _dateTime;
        private String _string;
        public Lap (DateTime dateTime, String string)
        {
            _dateTime = dateTime;
            _string = string;
        }
        public DateTime dateTime
        {
            get
            {
                return _dateTime;
            }
            set
            {
                _dateTime = value;
            }
        }
        public String string
        {
            get
            {
                return _string;
            }
            set
            {
                _string = value;
            }
        }
    }
