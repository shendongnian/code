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
        public void doStuff()
        {
            Console.WriteLine("A did stuff");
        }
    }
    
    class Mapper : A
    {
        new public virtual void doStuff() //notice the new and virtual keywords here which will all to hide or override the base class implementation
        {
            Console.WriteLine("Mapper did stuff");
        }
    }
    class B : Mapper
    {
        public override void doStuff()
        {
            Console.WriteLine("B did stuff");
        }
    }
