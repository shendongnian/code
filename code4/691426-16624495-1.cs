    class Program
    {
        static void Main(string[] args)
        {
            var dc = new DerivedClass();
            System.Console.Read();
        }
    }
    class BaseClass
    {
        public BaseClass(){
            System.Console.WriteLine("base");
        }
    }
    class DerivedClass : BaseClass
    {
        public DerivedClass()
            : base()
        {
            System.Console.WriteLine("derived");
        }
    }
