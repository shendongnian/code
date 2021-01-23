    class Program
    {
        public static void Main()
        {
            string[] list1 = new[] { "James", "Jack", "Laura", "Harry" };
            string[] list2 = new[] { "Jeffery", "Peters", "Smith" };
            var result = list1.SelectMany(i1 => list2.Select(i2 => i1 + " " + i2));
            foreach (string s in result)
            {
                Console.WriteLine(s);
            }
        }
    }
