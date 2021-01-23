    class Lap
    {
        private DateTime _dateTime;
        private String _string;
        public Lap (DateTime dateTimeValue, String stringValue)
        {
            _dateTime = dateTimeValue;
            _string = stringValue;
        }
        public DateTime DateTimeValue
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
        public String StringValue
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
