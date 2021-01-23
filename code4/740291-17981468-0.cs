    abstract class A : X
    {
        public virtual void Foo()
        {
            //Foo logic
        }
    }
    
    abstract class B : A
    {
        protected virtual void Foo2()
        {
            //Foo2
        }
    
        override void Foo()
        {
            Foo2();
            base.Foo();
        }
    }
    
    public A1 : B
    {
    }
    
    public A2 : A
    {
    }
    
    public A3 : B
    {
    }
