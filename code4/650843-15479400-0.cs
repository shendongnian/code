    class Program
    {
        static void Main(string[] args)
        {
            
            var ret1 = GetValue("String");
            Console.WriteLine(ret1);
            var ret2 = GetValue((object)"test");
            Console.WriteLine(ret2);
            Console.ReadKey();
        }
        private static object GetValue(string p0)
        {
            return p0;
        }
        private static object GetValue(object p0)
        {
            return "Object";
        }
    }
