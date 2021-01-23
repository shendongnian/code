    class B : A
    {
        public virtual void M()
        {
            Console.WriteLine("B");
        }
    }
    class C : B
    {
        public override void M() // I need to use public new void M() to avoid the warning
        {
            Console.WriteLine("C");
        }
    }
