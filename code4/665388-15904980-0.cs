    class speedtest
    {
        static void Main(string[] args)
        {
            int size = 10000000;
            Dictionary<string, object> valuesDict = new Dictionary<string, object>();
            List<object> valuesList = new List<object>();
            for (int i = 0; i < size; i++)
            {
                valuesDict.Add(i.ToString(), i);
                valuesList.Add(i);
            }
            // valuesDict loaded with thousands of objects
            Stopwatch s = new Stopwatch();
            s.Start();
            foreach (object value in valuesDict.Values) { /* process */ }
            s.Stop();
            Stopwatch s2 = new Stopwatch();
            s2.Start();
            foreach (object value in valuesList) { /* process */ }
            s.Stop();
            Console.WriteLine("Size {0}, Dictonary {1}ms, List {2}ms",size,s.ElapsedMilliseconds,s2.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
    Outputs:
    Size 10000000, Dictonary 73ms, List 63ms
