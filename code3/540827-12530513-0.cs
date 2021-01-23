        static void Main(string[] args)
        {
            List<string> col = new List<string>();
            col.Add("a");
            Console.WriteLine(Has_3(col));
            Console.ReadKey();
            col.Add("a");
            Console.WriteLine(Has_3(col));
            Console.ReadKey();
            col.Add("a");
            Console.WriteLine(Has_3(col));
            Console.ReadKey(); 
            col.Add("a");
            Console.WriteLine(Has_3(col));
            Console.ReadKey();
        }
        static bool Has_3(List<string> col)
        {
            return col.Count(x => x == "a").Equals(3);
        }
