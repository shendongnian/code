    class FuncExample
    {
        static void Main(string[] args)
        {
            var funcs = new List<Func<int>> { a, b, c };
            foreach (var f in funcs)
            {
                Console.WriteLine(f());
            }
        }
        private static int a()
        {
            return 1;
        }
        private static int b()
        {
            return 2;
        }
        private static int c()
        {
            return 3;
        }
    }
