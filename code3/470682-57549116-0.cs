        static void Main(string[] args)
        {
            string[] ar = { "apple", "orange", "banana", "pear", "lemon" };
            int half =  ar.Length / 2;
            //  Console.WriteLine(string.Join(',', SplitArray(ar,0, half)));
            Console.WriteLine(string.Join(',', SplitArray(ar,half, ar.Length)));
            Console.ReadKey();
        }
        public static IEnumerable<T> SplitArray<T>(T[] ar, int start, int end)
        {
            return ar.Skip(start).Take(end);
        }
