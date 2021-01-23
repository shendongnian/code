    class SomeClass : MarshalByRefObject
    {
        public int Mul(int a, int b)
        {
            return a * b;
        }
    
        public void SetValue(int val)
        {
            this.Val = val;
        }
    
        public int Val { get; set; }
    }
