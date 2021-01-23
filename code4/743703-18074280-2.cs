    class Program
    {
        static void Main(string[] args)
        {
            var tempList = new List<int>();
            var tempDict = new Dictionary<int, int>();
            for (int i = 0; i < 100000; i++)
            {
                tempList.Add(i);
                tempDict.Add(i, i);
            }
            for (int k = 0; k < 10; k++)
            {
                var takeFrom = k * 500;
                var insertAt = 0;
                Console.WriteLine("The interval is {0}", takeFrom - insertAt);
                var s = new Stopwatch();
                s.Start();
                for (int i = 0; i < 10000; i++)
                {
                    tempList.Insert(insertAt, tempList[takeFrom]);
                    tempList.RemoveAt(takeFrom + 1);
                }
                Console.WriteLine(s.Elapsed);
                s.Restart();
                for (int i = 0; i < 10000; i++)
                {
                    var e = tempDict[takeFrom];
                    for (int j = takeFrom - insertAt; j > insertAt; j--)
                    {
                        tempDict[j] = tempDict[j - 1];
                    }
                    tempDict[insertAt] = e;
                }
                Console.WriteLine(s.Elapsed);
                s.Stop();
            }
        }
    }
