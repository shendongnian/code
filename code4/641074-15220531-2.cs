    public class B: A
    {      
    }
     
    static void Main()
    {
        A a = new A();
        B b = new B();
        Console.Write(a.dtA == b.dtA); //true
    }
