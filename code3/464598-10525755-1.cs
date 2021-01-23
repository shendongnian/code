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
            // If you reverse the inheritance on code above
            // As Ben Voigt noticed, *as A* is redundant. should be removed
            // A a = GetB() as A; 
            // should be this. B is wider than A, so A can accept B, no need to cast
            A a = GetB(); 
            Console.WriteLine(a == null); // it is null!
    
            Console.WriteLine("Console.ReadKey();");
            Console.ReadKey();
        }
        public static B GetB()
        {
            return new B();
        }
    }
