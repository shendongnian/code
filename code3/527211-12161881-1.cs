    class Program
    {
        static void Main()
        {
            dynamic dyna = new ExpandoObject();
            dyna.key = "value";
            Test(dyna.key);
        }
    
        public static void Test(string message)
        {
            Console.WriteLine(message);
        }
    }
