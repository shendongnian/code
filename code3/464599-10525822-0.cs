    public class A : B
    {
        public A(B b)
        {
            //perform your conversion of a B into an A
        }
    }
    public class B
    {
        public B(){}
    }
    static void Main(string[] args)
    {
        B b = new B();
        A a = new A(b);
        Console.WriteLine(a == null); // it is null!
        Console.WriteLine("Console.ReadKey();");
        Console.ReadKey();
    }
