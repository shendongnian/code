    //Base Class
    class Foo
    {
        public virtual bool DoSomething()
        {
            return true;
        }
    }
    
    // Derived Class
    class Bar : Foo
    {
        public override bool DoSomething()
        {
            if (base.DoSomething())
            {
               // base.DoSomething() returned true
            }
            else
            {
               // base.DoSomething() returned false
            }
        }
    }
