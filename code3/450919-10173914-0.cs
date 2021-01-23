    class A
    {
        public virtual void VirtualParentMethod()
        {
            Foo();
        }
    
        protected void Foo()
        {
            Console.WriteLine("A");
        }
    }
    class B : A
    {
        public override void VirtualParentMethod()
        {
            Console.WriteLine("B");
        }
    }
    class C : B
    {
        public override void VirtualParentMethod()
        {        
            Foo();
        }
    }
