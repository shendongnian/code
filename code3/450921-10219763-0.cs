    class A
    {
        public virtual void virtualParentMethod()
        {
            Console.WriteLine("A");
        }
    }
    class B : A
    {
        public new void virtualParentMethod()
        {
            Console.WriteLine("B");
        }
    }
    class C : B
    {
        public new void virtualParentMethod()
        {
            // casting this to A will allow you to call the base class implementation
            ((A)this).virtualParentMethod();
        }
    }
