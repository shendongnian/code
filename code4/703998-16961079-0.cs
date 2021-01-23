    class A
    {
    public virtual void print()
    {
    System.Console.WriteLine("Inside Parent");
    }
    }
    class B : A
    {
    public override void print()
    {
    System.Console.WriteLine("Inside Child");
    }
    }
    class Program
    {
    public static void Main(string[] args)
    {
    B b1=new B();
    b1.print();
    A a1=new B();
    a1.print();
    System.Console.Read();
    }
    }
