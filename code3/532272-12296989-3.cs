    class Program
    {
        static void Main()
        {
            char[] text = "Some String".ToCharArray();
            int numThreads = 5;
            // I leave the implementation of the next line to the OP.
            Partition[] partitions = PartitionWork(text, numThreads);
            completions = new WaitHandle[numThreads];
            results = IDictionary<char, int>[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                results[i] = new IDictionary<char, int>();
                completions[i] = new ManualResetEvent(false);
                new Thread(DoWork).Start(
                    text,
                    partitions[i].Start,
                    partitions[i].End,
                    results[i],
                    completions[i]);
            }
            if (WaitHandle.WaitAll(completions, new TimeSpan(366, 0, 0, 0))
            {
                Console.WriteLine("All threads finished");
            }
            else
            {
                Console.WriteLine("Timed out after a year and a day");
            }
            // Merge the results
            IDictionary<char, int> result = results[0];
            for (int i = 1; i < numThreads - 1; i ++)
            {
                foreach(KeyValuePair<char, int> item in results[i])
                {
                    if (result.ContainsKey(item.Key)
                    {
                        result[item.Key] += item.Value;
                    }
                    else
                    {
                       result.Add(item.Key, item.Value);
                    }
                }
            }
        }
        static void BuildDictionary(
            char[] text, 
            int start, 
            int finish,
            IDictionary<char, int> result,
            WaitHandle completed)
        {
            for (int i = start; i <= finish; i++)
            {
                if (result.ContainsKey(text[i])
                {
                    result[text[i]]++;
                }
                else
                {
                   result.Add(text[i], 1);
                }
            }
            completed.Set();
        }
    }
