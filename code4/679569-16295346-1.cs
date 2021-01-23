    class A
    {
        public virtual int CallMe(string incString)
        {
            // some code    
        }
    }
    
    class B : A
    {
        public override void CallMe(string incString)
        {
            // some code
        }
    }
    // somewhere in the code (e.g., host application, which loads a plugin)
    var a = serviceLocator.GetService<A>(); // indeed returns `B` instance 
    var result = a.CallMe(); // hey, stop! B.CallMe is void. WTF?
