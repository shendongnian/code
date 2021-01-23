        static void Main(string[] args)
        {
            Action d = () => Console.WriteLine("Hi");
            Execute(d, null);
            Action<string> d2 = (s) => Console.WriteLine(s);
            Execute(d2, new object[] {"Lo"});
            Func<string, string> d3 = (s) =>
            {
                Console.WriteLine(s);
                return "Done";
            };
            var result = (string)Execute(d3, new object[] {"Spaghettio"});
            Console.WriteLine(result);
            Console.Read();
        }
        static object Execute(Delegate d, object[] args)
        {
            return d.DynamicInvoke(args);
        }
