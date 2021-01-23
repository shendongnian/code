    public abstract class Abstract
    {
        public Abstract()
        {
            Console.WriteLine("Abstract");
        }
    }
    
    public class Derived : Abstract
    {
        public Derived() : base()
        {
            Console.WriteLine("Derived");
        }
    }
    
    public class Class1
    {
        public static void Main(string[] args)
        {
            Derived d = new Derived();
        }
    }
