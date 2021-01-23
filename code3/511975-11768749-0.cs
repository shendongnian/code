    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();
            IEnumerable<object> objects = list;
            Func<string, bool> func = s => s.Contains("x");
            list.Add("Test");
            list.Add("x");
            list.Add("mux");
            foreach (var item in objects.Cast<dynamic>().Where(d => func(d)))
                Console.WriteLine(item);
            Console.ReadKey();
        }
    }
