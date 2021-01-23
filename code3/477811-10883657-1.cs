    using A;
    using B;
    static void Main(string[] args)
    {
        Customer c = new Customer();
    }
    
    //AssemblyA.dll
    namespace A { public class Customer { } }
    //AssemblyB.dll
    namespace B { public class Customer { } }
