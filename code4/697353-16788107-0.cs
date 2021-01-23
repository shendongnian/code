        public static void Main(string[] args)
        {
            IFoo badFoo = new BadFoo();
            IFoo niceFoo = new NiceFoo();
            PrintObjectType("BadFoo", badFoo);
            PrintObjectType("NiceFoo", niceFoo);
            PrintGenericType("BadFoo", badFoo);
            PrintGenericType("NiceFoo", niceFoo);
        }
        public static void PrintObjectType(string actualName, object instance)
        {
            Console.WriteLine("Object {0} says he's a '{1}'", actualName, instance.GetType());
        }
        public static void PrintGenericType<T>(string actualName, T instance)
        {
            Console.WriteLine("Generic Type {0} says he's a '{1}'", actualName, instance.GetType());
        }
