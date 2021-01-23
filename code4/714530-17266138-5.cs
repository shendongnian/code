    class MyClassA
    {
        public MyClassA
        {
            if (failed)
                OnFail();
        }
        
        protected virtual void OnFail()
        {
             throw new Exception();
        }
    }
    class MyClassB : MyClassA
    {
        protected override void OnFail()
        {
            // don't throw
        }
    }   
