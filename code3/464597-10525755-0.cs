    class Program
    {
        public class A : B  // should be: public class A
        {
        }
    
        public class B // should be: public class B : A
        {
        }
    
        static void Main(string[] args)
        {
            // A a = GetB() as A; // As Ben Voigt noticed, should be removed
            A a = GetB(); should be this 
            Console.WriteLine(a == null); // it is null!
    
            Console.WriteLine("Console.ReadKey();");
            Console.ReadKey();
        }
        public static B GetB()
        {
            return new B();
        }
    }
