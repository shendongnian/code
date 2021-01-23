    class Program
    {
        static void Main(string[] args)
        {
            // creates a type whose methods and properties are all like Int32, but with an UnderlyingSystemType of string
            var type = new MyType(typeof(int));
            Console.WriteLine(type.FullName); // prints System.Int32
            Console.WriteLine(type.UnderlyingSystemType.FullName); // prints System.String
        }
    }
    class MyType : TypeDelegator //this extends Type, which is an abstract class
    {
        public MyType(Type t) : base(t) { }
        public override Type UnderlyingSystemType
        {
            get
            {
                return typeof(string);
            }
        }
    }
