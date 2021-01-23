    class A
    {
        public IA Data { get; private set; }
        public IBefore Before { get; set; }
        
        public A(IA data)
        {
            this.Data = data;
        }
        public void Increment()
        {
            // here should be design decision: if Before is optional…
            if(Before == null)
            {
                Before.DoStuffBefore();
            }    
            
            // …or required
            if(Before == null)
            {
                throw new Exception("'Before' is required");
            }
            
            Data.Data++;
        }
    }
