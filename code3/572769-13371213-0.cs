        private static StreamWriter stdout = new StreamWriter(Console.OpenStandardOutput());
        static void Main(string[] args)
        {
            Action<string>[] tests = new Action<string>[] { Test1, Test2, Test3 };
            TimeSpan[] timming = new TimeSpan[tests.Length];
            // Repeat the entire sequence of tests many times to accumulate the result
            for (int i = 0; i < 100; i++)
            {
                for( int itest =0; itest < tests.Length; itest++)
                {
                    string text = String.Format("just a little test string, test = {0}, iteration = {1}", itest, i);
                    Action<string> thisTest = tests[itest];
                    //Clear the console so that each test begins from the same state
                    Console.Clear();
                    var timer = Stopwatch.StartNew();
                    //Repeat the test many times, if this was not using the console 
                    //I would use a much higher number, say 10,000
                    for (int j = 0; j < 100; j++)
                        thisTest(text);
                    timer.Stop();
                    //Accumulate the result, but ignore the first run
                    if (i != 0)
                        timming[itest] += timer.Elapsed;
                    //Depending on what you are benchmarking you may need to force GC here
                }
            }
            //Now print the results we have collected
            Console.Clear();
            for (int itest = 0; itest < tests.Length; itest++)
                Console.WriteLine("Test {0} = {1}", itest + 1, timming[itest]);
            Console.ReadLine();
        }
        static void Test1(string str)
        {
            Console.WriteLine(str);
        }
        static void Test2(string str)
        {
            foreach (var c in str)
                Console.Write(c);
            Console.Write('\n');
        }
        static void Test3(string str)
        {
            foreach (var c in str)
                stdout.Write(c);
            stdout.Write('\n');
        }
