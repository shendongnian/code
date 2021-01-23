    class Program
    {
        static void Main(string[] args)
        {
            var listOfInt = new List<int> {7, 4, 2, 5, 7, 5, 4, 3, 4, 5, 6, 3, 7, 5, 7, 4, 2};
    
            var histogram = BuildHistogram1(listOfInt);
    
            var modeValue = FindMode(histogram);
    
            Console.WriteLine(modeValue);
        }
    
        private static int FindMode(Dictionary<int, int> histogram)
        {
            int mode = 0;
            int count = 0;
            foreach (KeyValuePair<int, int> pair in histogram)
            {
                if( pair.Value>count)
                {
                    count = pair.Value;
                    mode = pair.Key;
                }
            }
            return mode;
        }
    
        private static Dictionary<int,int> BuildHistogram1(List<int> listOfInt)
        {
            var histogram = new Dictionary<int, int>();
            foreach (var v in listOfInt)
            {
                if (histogram.ContainsKey(v))
                    histogram[v] = histogram[v] + 1;
                else
                    histogram[v] = 1;
            }
            return histogram;
        }
    }
