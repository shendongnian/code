        static void Main(string[] args)
        {
            Action d = () => Console.WriteLine("Hi");
            Execute(d); // Prints "Hi"
            Action<string> d2 = (s) => Console.WriteLine(s);
            Execute(d2, "Lo"); // Prints "Lo"
            Func<string, string> d3 = (s) =>
            {
                Console.WriteLine(s);
                return "Done";
            };
            var result = (string)Execute(d3, "Spaghettio"); // Prints "Spaghettio"
            Console.WriteLine(result); // Prints "Done"
            Console.Read();
        }
        static object Execute(Delegate d, params object[] args)
        {
            return d.DynamicInvoke(args);
        }
