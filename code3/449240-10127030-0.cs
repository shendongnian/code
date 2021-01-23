    static void Main(string[] args)
    {
        var input = Console.ReadLine();
            var test = new ListArrayLoop(10000, 1000);
            switch (input)
            {
                case "1":
                    Test(test.ListSum);
                    break;
                case "2":
                    Test(test.ArraySum);
                    break;
                case "3":
                    // adds about 40 ms
                    test.ArraySum();
                    Test(test.ListSum);
                    break;
                default:
                    // adds about 35 ms
                    test.ListSum();
                    Test(test.ArraySum);
                    break;
            }
    }
    private static void Test(Action toTest)
    {
        for (int i = 0; i < 100; i++)
        {
            var sw = Stopwatch.StartNew();
            toTest();
            sw.Stop();
            Console.WriteLine("costs {0}", sw.ElapsedMilliseconds);
            sw.Reset();
        }
    }
