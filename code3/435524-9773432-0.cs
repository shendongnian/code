        public static Dictionary<char, int> Count(string input)
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (d.Keys.Contains(c))
                    d[c]++;
                else
                    d.Add(c, 1);
            }
            return d;
        }
        static void Main(string[] args)
        {
            Dictionary<char, int> d = Count("Red House");
            foreach (char c in d.Keys)
            {
                Console.WriteLine("{0}: {1}", c, d[c]);
            }
            Console.ReadKey();
        }
