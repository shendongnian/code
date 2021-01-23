    class A {}
    class B : A {}
    class Program
    {
        static A CreateA()
        {
            return new B();
        }
     
        static void Main()
        { 
            A a = CreateA();
            Console.WriteLine(typeof(A));     // Writes "A"
            Console.WriteLine(a.GetType());   // Writes "B"
        }
    }
