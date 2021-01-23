    public struct Meter
    {
        public int Value;
    
        public Meter(int value)
        {
            this.Value = value;
        }
    
        public static implicit operator Meter(int a)
        {
             return new Meter(a);
        }
    }
    public struct Second
    {
        public int Value;
    
        public Second(int value)
        {
            this.Value = value;
        }
    
        public static implicit operator Second(int a)
        {
             return new Second(a);
        }
    }
