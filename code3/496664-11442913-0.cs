    class Program
    {
        private static readonly string file = @"movies.list";
        private static readonly int testStart = 1;
        private static readonly int numOfTests = 2;
        private static readonly int MinTimingVal = 1000;
        private static string[] testNames = new string[] {            
            "Naive",
            "OneCallToWrite",
            "SomeCallsToWrite",
            "InParallel",
            "InParallelBlcoks",
            "IceManMinds",
            "TestTiming"
            };
        private static double[] avgSecs = new double[numOfTests];
        private static int[] testIterations = new int[numOfTests];
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting tests...");
            Debug.WriteLine("Starting tests...");
            Console.WriteLine("");
            Debug.WriteLine("");
            //*****************************
            //The console is the bottle-neck, so we can
            //speed-up redrawing it by only showing 1 line at a time.
            Console.WindowHeight = 1;
            Console.WindowWidth = 50;
            Console.BufferHeight = 100;
            Console.BufferWidth = 50;
            //******************************
            Action[] actionArray = new Action[numOfTests];
            actionArray[0] = naive;
            actionArray[1] = oneCallToWrite;
            actionArray[2] = someCallsToWrite;
            actionArray[3] = inParallel;
            actionArray[4] = inParallelBlocks;
            actionArray[5] = iceManMinds;
            actionArray[6] = testTiming;
            
            for (int i = testStart; i < actionArray.Length; i++)
            {
                Action a = actionArray[i];
                DoTiming(a, i);
            }
            printResults();
            Console.WriteLine("");
            Debug.WriteLine("");
            Console.WriteLine("Tests complete.");
            Debug.WriteLine("Tests complete.");
            Console.WriteLine("Press Enter to Close Console...");
            Debug.WriteLine("Press Enter to Close Console...");
            Console.ReadLine();
        }
        private static void DoTiming(Action a, int num)
        {
            a.Invoke();
            Stopwatch watch = new Stopwatch();
            Stopwatch loopWatch = new Stopwatch();
            bool shouldRetry = false;
            int numOfIterations = 2;
            do
            {
                watch.Start();
                for (int i = 0; i < numOfIterations; i++)
                {
                    a.Invoke();
                }
                watch.Stop();
                shouldRetry = false;
                if (watch.ElapsedMilliseconds < MinTimingVal) //if the time was less than the minimum, increase load and re-time.
                {
                    shouldRetry = true;
                    numOfIterations *= 2;
                    watch.Reset();
                }
            } while (shouldRetry);
            long totalTime = watch.ElapsedMilliseconds;
            double avgTime = ((double)totalTime) / (double)numOfIterations;
            avgSecs[num] = avgTime / 1000.00;
            testIterations[num] = numOfIterations;
        }
        private static void printResults()
        {
            Console.WriteLine("");
            Debug.WriteLine("");
            for (int i = testStart; i < numOfTests; i++)
            {
                TimeSpan t = TimeSpan.FromSeconds(avgSecs[i]);
                Console.WriteLine("ElapsedTime: {0:N4}, " + "test: " + testNames[i], t.ToString() );
                Debug.WriteLine("ElapsedTime: {0:N4}, " + "test: " + testNames[i], t.ToString() );
            }
        }
        public static void naive()
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None, 8, FileOptions.None);
            using (StreamReader sr = new StreamReader(fs))
            {
                while (sr.Peek() >= 0)
                {
                     Console.WriteLine( sr.ReadLine() );
                }
            }
        }
        public static void oneCallToWrite()
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None, 8, FileOptions.None);
            using (StreamReader sr = new StreamReader(fs))
            {
                StringBuilder sb = new StringBuilder();
                while (sr.Peek() >= 0)
                {
                    string s = sr.ReadLine();
                    sb.Append("\n" + s);
                }
                Console.Write(sb);
            }
        }
        public static void someCallsToWrite()
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None, 8, FileOptions.None);
            using (StreamReader sr = new StreamReader(fs))
            {
                StringBuilder sb = new StringBuilder();
                int count = 0;
                int mod = 10000;
                while (sr.Peek() >= 0)
                {
                    count++;
                    string s = sr.ReadLine();
                    sb.Append("\n" + s);
                    if (count % mod == 0)
                    {
                        Console.Write(sb);
                        sb = new StringBuilder();
                    }
                }
                Console.Write( sb );
            }
        }
        public static void inParallel()
        {
            string[] wordsFromFile = File.ReadAllLines( file );
            int length = wordsFromFile.Length;
            Parallel.For( 0, length, i => {
                Console.WriteLine( wordsFromFile[i] );
                
            });
              
        }
        public static void inParallelBlocks()
        {
            string[] wordsFromFile = File.ReadAllLines(file);
            int length = wordsFromFile.Length;
            Parallel.For<StringBuilder>(0, length,
                () => { return new StringBuilder(); },
                (i, loopState, sb) =>
                {
                    sb.Append("\n" + wordsFromFile[i]);
                    return sb;
                },
                (x) => { Console.Write(x); }
            );
        }
        #region iceManMinds
        public static void iceManMinds()
        {
            string FileName = file;
            long ThreadReadBlockSize = 50000;
            int NumberOfThreads = 4;
            byte[] _inputString;
            var fi = new FileInfo(FileName);
            long totalBytesRead = 0;
            long fileLength = fi.Length;
            long readPosition = 0L;
            Console.WriteLine("Reading Lines From {0}", FileName);
            var threads = new Thread[NumberOfThreads];
            var instances = new ReadThread[NumberOfThreads];
            _inputString = new byte[fileLength];
            while (totalBytesRead < fileLength)
            {
                for (int i = 0; i < NumberOfThreads; i++)
                {
                    var rt = new ReadThread { StartPosition = readPosition, BlockSize = ThreadReadBlockSize };
                    instances[i] = rt;
                    threads[i] = new Thread(rt.Read);
                    threads[i].Start();
                    readPosition += ThreadReadBlockSize;
                }
                for (int i = 0; i < NumberOfThreads; i++)
                {
                    threads[i].Join();
                }
                for (int i = 0; i < NumberOfThreads; i++)
                {
                    if (instances[i].BlockSize > 0)
                    {
                        Array.Copy(instances[i].Output, 0L, _inputString, instances[i].StartPosition,
                                   instances[i].BlockSize);
                        totalBytesRead += instances[i].BlockSize;
                    }
                }
            }
            string finalString = Encoding.ASCII.GetString(_inputString);
            Console.WriteLine(finalString);//.Substring(104250000, 50000));
        }
        private class ReadThread
        {
            public long StartPosition { get; set; }
            public long BlockSize { get; set; }
            public byte[] Output { get; private set; }
            public void Read()
            {
                Output = new byte[BlockSize];
                var inStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                inStream.Seek(StartPosition, SeekOrigin.Begin);
                BlockSize = inStream.Read(Output, 0, (int)BlockSize);
                inStream.Close();
            }
        }
        #endregion
        public static void testTiming()
        {
            Thread.Sleep(500);
        }
    }
