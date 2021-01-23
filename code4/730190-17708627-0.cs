    public class Money
    {
        private float _raw;
    
        public float Raw
        {
            get { return _raw; }
            set { _raw = value; }
        }
    
        public string Pound
        {
            get { return "£" + string.Format("{0:0.00}", _raw); }
        }
    
       
        public static implicit operator Money(float value)
        {
            return new Money(){Raw = value};
        }
    }
