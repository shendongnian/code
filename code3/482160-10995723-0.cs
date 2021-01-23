    class A : IDoSomething
    {
        public virtual void DoSomething()
        {
            //do A
        }
    }
    
    class B : A
    {
        public override void DoSomething()
        {
            //do B
        }
    }
