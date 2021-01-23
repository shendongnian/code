    class Program
    {
        const int Loops = 10000;
        const int TakeLoops = 10;
        const int ItemsCount = 100000;
        const int Multiplier = 500;
        const int InsertAt = 0;
        static void Main(string[] args)
        {
            var tempList = new List<int>();
            var tempDict = new Dictionary<int, int>();
            for (int i = 0; i < ItemsCount; i++)
            {
                tempList.Add(i);
                tempDict.Add(i, i);
            }
            var limit = 0;
            Stopwatch
                sG = new Stopwatch(),
                s1 = new Stopwatch(),
                s2 = new Stopwatch();
            TimeSpan
                t1 = new TimeSpan(),
                t2 = new TimeSpan();
            for (int k = 0; k < TakeLoops; k++)
            {
                var takeFrom = k * Multiplier + InsertAt;
                s1.Restart();
                for (int i = 0; i < Loops; i++)
                {
                    tempList.Insert(InsertAt, tempList[takeFrom]);
                    tempList.RemoveAt(takeFrom + 1);
                }
                s1.Stop();
                t1 += s1.Elapsed;
                s2.Restart();
                for (int i = 0; i < Loops; i++)
                {
                    var e = tempDict[takeFrom];
                    for (int j = takeFrom - InsertAt; j > InsertAt; j--)
                    {
                        tempDict[InsertAt + j] = tempDict[InsertAt + j - 1];
                    }
                    tempDict[InsertAt] = e;
                }
                s2.Stop();
                t2 += s2.Elapsed;
                if (s2.Elapsed > s1.Elapsed || limit == 0)
                    limit = takeFrom;
            }
            sG.Start();
            for (int k = 0; k < TakeLoops; k++)
            {
                var takeFrom = k * Multiplier + InsertAt;
                if (takeFrom >= limit)
                {
                    for (int i = 0; i < Loops; i++)
                    {
                        tempList.Insert(InsertAt, tempList[takeFrom]);
                        tempList.RemoveAt(takeFrom + 1);
                    }
                }
                else
                {
                    for (int i = 0; i < Loops; i++)
                    {
                        var e = tempDict[takeFrom];
                        for (int j = takeFrom - InsertAt; j > InsertAt; j--)
                        {
                            tempDict[InsertAt + j] = tempDict[InsertAt + j - 1];
                        }
                        tempDict[InsertAt] = e;
                    }
                }
            }
            sG.Stop();
            Console.WriteLine("List:       {0}", t1);
            Console.WriteLine("Dictionary: {0}", t2);
            Console.WriteLine("Optimized:  {0}", sG.Elapsed);
            /***************************
            List:       00:00:11.9061505
            Dictionary: 00:00:08.9502043
            Optimized:  00:00:08.2504321
            ****************************/
        }
    }
