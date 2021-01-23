    class A
    {
        public virtual void doStuff()
        {
            Console.WriteLine("A did stuff");
        }
    }
    
    class B : A
    {
        public override void doStuff()
        {
            Console.WriteLine("B did stuff");
        }
    }
