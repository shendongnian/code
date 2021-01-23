    public class Base
    {
        public void Extends()
        {
            Console.WriteLine("Base class");
        }
    }
    public class Extend : Base
    {
        public new void Extends()
        {
            Console.WriteLine("Extend class");
        }
    }
    public class Program
    {
        public static void Main()
        {
            Base b = new Base();
            b.Extends();
            Extend e = new Extend();
            e.Extends();
            Base be = new Extend();
            be.Extends();
            Console.Read();
       }
    }
