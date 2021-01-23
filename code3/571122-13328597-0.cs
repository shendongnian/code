    class Program
    {
        public ICollection<string> Foo() { return new List<string>(); } 
        public static bool TestType()
        {
            MethodInfo info = typeof(Program).GetMethod("Foo");
            return info.ReturnType.GetGenericTypeDefinition() == typeof(ICollection<>);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("{0} is ICollection<> : {1}", "Foo", TestType());
        }
    }
