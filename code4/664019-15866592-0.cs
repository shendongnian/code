    class Program
    {
        static void Main(string[] args)
        {
            var input = new[] { "A", "C", "B", "A", "C", "D", "A" };
            var result = Filter(input);
            Console.WriteLine(result);
        }
    
        static IEnumerable<T> Filter<T>(IEnumerable<T> items)
        {
            var dictionary = new Dictionary<T, int>();
    
            //first scan of the input
            foreach (T item in items)
            {
                if (dictionary.ContainsKey(item))
                {
                    dictionary[item]++;
                }
                else
                {
                    dictionary[item] = 1;
                }
            }
    
            //second scan
            return from x in dictionary
                    where x.Value == 1
                    select x.Key;
        }
    }
