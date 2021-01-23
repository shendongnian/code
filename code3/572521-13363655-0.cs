    public interface IFoo
    {
        void Foo();
    }
    
    public class A : IFoo
    {
        public void Foo()
        {
            Console.WriteLine("I am A, hear me roar!");
        }
    }
    
    public class B : IFoo
    {
        public void Foo()
        {
            Console.WriteLine("I am B, hear me roar!");
        }
    }
    
    private static void Main(string[] args)
    {
        IFoo foo = new A();
        foo.Foo();
    
        foo = new B();
        foo.Foo();
    
        Console.WriteLine();
        Console.WriteLine("Press any key to exit . . .");
        Console.ReadKey(true);
    }
