        static void Main(string[] args)
        {
            string[] ar = { "apple", "orange", "banana", "pear", "lemon" };
            int half =  ar.Length / 2;
            //  Console.WriteLine(string.Join(',', Split(ar,0, half)));
            Console.WriteLine(string.Join(',', Split(ar,half, ar.Length)));
            Console.ReadKey();
        }
        
        public static IEnumerable<T> Split<T>(IEnumerable<T> items, int start, int end)
        {
            return items.Skip(start).Take(end);
        }
