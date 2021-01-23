    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = {"a", "b", "c", "d", "e"};
            string[] array2 = {"x", "y", "a", "b", "a"};
            
            var histogram = new Dictionary<string, int>();
            Fill(histogram, array1);
            Fill(histogram, array2);
    
            foreach (var p in histogram)
            {
                Console.WriteLine("{0}={1}",p.Key,p.Value);
            }
        }
    
        private static void Fill(Dictionary<string, int> histogram, string[] a)
        {
            foreach (string s in a)
            {
                if (histogram.ContainsKey(s))
                    histogram[s] += 1;
                else
                    histogram[s] = 1;
            }
        }
    }
