    public class Money {
        private float _raw;
    
        public float Raw {
            get {  return _raw;  }
            set {  _raw = value;  }
        }
    
        public string Pound {
            get {  return "£" + string.Format("{0:0.00}", _raw);  }
        }
        public static Money From(float val) 
        {
            Money x = new Money();
            x.Raw = val;
            return x;
        }
    } 
