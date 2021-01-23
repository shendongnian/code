    public partial class DTVitem
    {
        private DateTime _datevalue;
    
        public string dt
        {
            get { return _datevalue.ToString(); }
            set { DateTime.TryParse(value, out _datevalue) ;}
        }
    }
