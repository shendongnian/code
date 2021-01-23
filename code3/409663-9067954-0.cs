    class Program
    {
        static void Main(string[] args)
        {
            A a = new B(); //notice this line
            B b = new B();
    
            a.doStuff();
            b.doStuff();
    
            Console.ReadLine();
        }
    }
    
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
