    using A;
    static void Main(string[] args)
    {
        Customer c = new Customer();
    }
    
    //AssemblyA.dll
    namespace A { public class Customer { } }
        
    //AssemblyB.dll
    namespace A { public class Customer { } }
