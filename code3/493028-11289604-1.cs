    class Program
    {
        private static readonly string filename1 = "DictoFile1.txt";
        private static readonly string filename2 = "DictoFile2.txt";
        private static readonly int numOfTests = 6;
        private static readonly int MinTimingVal = 1000;
        private static string[] testNames = new string[] {            
            "ManningsBaseCase1:   ",
            "ManningsBaseCase2:   ",
            "KevinsLINQ1:         ",
            "KevinsLINQ2:         ",
            "ManningsOldMerge:    ",
            "ManningsCleanMerge:  "
            };
        private static string[] prev;
        private static string[] next;
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting tests...");
            Debug.WriteLine("Starting tests...");
            Console.WriteLine("");
            Debug.WriteLine("");
            Action[] actionArray = new Action[numOfTests];
            actionArray[0] = ManningsBaseCase1;
            actionArray[1] = ManningsBaseCase2;
            actionArray[2] = KevinsLINQ1;
            actionArray[3] = KevinsLINQ2;
            actionArray[4] = ManningsOldInterleaved;
            actionArray[5] = ManningsCleanInterleaved;
            for( int i = 0; i < actionArray.Length; i++ )
            {
                Console.Write(testNames[i]);
                Debug.Write(testNames[i]);
                Action a = actionArray[i];
                DoTiming(a, i);
                if (i > 0)
                {
                    if (!ValidateLists())
                    {
                        Console.WriteLine(" --- Validation had an error.");
                        Debug.WriteLine(" --- Validation had an error.");
                    }
                }
                prev = next;
            }
            Console.WriteLine("");
            Debug.WriteLine("");
            Console.WriteLine("Tests complete.");
            Debug.WriteLine("Tests complete.");
            Console.WriteLine("Press Enter to Close Console...");
            Debug.WriteLine("Press Enter to Close Console...");
            Console.ReadLine();
        }
        private static bool ValidateLists()
        {
            if (prev == null) return false;
            if (next == null) return false;
            if (prev.Length != next.Length) return false;
            for (int i = 0; i < prev.Length; i++)
            {
                if (prev[i] != next[i]) return false;
            }
            return true;
        }
        private static void DoTiming( Action a, int num )
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
            } while ( shouldRetry );
            long totalTime = watch.ElapsedMilliseconds;
            double avgTime = ((double)totalTime) / (double)numOfIterations;
            Console.WriteLine("ElapsedTime: {0:N4}, numOfIterations: " + numOfIterations, avgTime/1000.00);
            Debug.WriteLine("ElapsedTime: {0:N4}, numOfIterations: " + numOfIterations, avgTime / 1000.00);
        }
        private static void ManningsBaseCase1()
        {
            string[] wordsFromFile1 = File.ReadAllLines( filename1 );
            string[] wordsFromFile2 = File.ReadAllLines( filename2 );
            IEnumerable<string> file1ExceptFile2 = wordsFromFile1.Except(wordsFromFile2);
            string[] asArray = file1ExceptFile2.ToArray();
            next = asArray;
        }
        private static void ManningsBaseCase2()
        {
            string[] wordsFromFile1 = File.ReadAllLines( filename1 );
            string[] wordsFromFile2 = File.ReadAllLines( filename2 );
            IEnumerable<string> file1ExceptFile2 = wordsFromFile1.Except(wordsFromFile2, StringComparer.OrdinalIgnoreCase);
            string[] asArray = file1ExceptFile2.ToArray();
            next = asArray;
        }
        private static IEnumerable<string> GetWordsFromFile(StreamReader _streamReader)
        {
            while (!_streamReader.EndOfStream)
            {
                yield return _streamReader.ReadLine();
            }
        }
        private static void KevinsLINQ1()
        {
            using (StreamReader _streamReader1 = new StreamReader(filename1))
            {
                using (StreamReader _streamReader2 = new StreamReader(filename2))
                {
                   IEnumerable<string> words = GetWordsFromFile(_streamReader1)
                        .Except(GetWordsFromFile(_streamReader2));
                   string[] asArray = words.ToArray();
                   next = asArray;
                }
            }
        }
        private static void KevinsLINQ2()
        {
            using (StreamReader _streamReader1 = new StreamReader(filename1))
            {
                using (StreamReader _streamReader2 = new StreamReader(filename2))
                {
                    IEnumerable<string> words = GetWordsFromFile(_streamReader1)
                        .Except(GetWordsFromFile(_streamReader2).AsParallel());
                    string[] asArray = words.ToArray();
                    next = asArray;
                }
            }
        }
        // Define other methods and classes here
        public static IEnumerable<string> ExceptSortedInputsOld(IEnumerable<string> inputSequence, IEnumerable<string> exceptSequence)
        {
            IEnumerator<string> exceptEnumerator = exceptSequence.GetEnumerator();
            IEnumerator<string> inputEnumerator = inputSequence.GetEnumerator();
            while (inputEnumerator.MoveNext())
            {
                // need to move the except sequence forward to ensure it's at or later than the current input word
                while (String.Compare(inputEnumerator.Current, exceptEnumerator.Current) == 1)
                {
                    if (exceptEnumerator.MoveNext() == false)
                    {
                        // stupid optimization - since there are no more except matches, we can just return the rest of the input
                        do
                        {
                            yield return inputEnumerator.Current;
                        }
                        while (inputEnumerator.MoveNext());
                        yield break;
                    }
                }
                // when we get here, we know the current 'except' word is equal to or later than the input one, so we can just check equality
                if (inputEnumerator.Current != exceptEnumerator.Current)
                {
                    yield return inputEnumerator.Current;
                }
            }
        }
        private static void ManningsOldInterleaved()
        {
            IEnumerable<string> wordsFromFile1 = File.ReadLines(filename1);
            IEnumerable<string> wordsFromFile2 = File.ReadLines(filename2);
            IEnumerable<string> file1ExceptFile2 = ExceptSortedInputsOld(wordsFromFile1, wordsFromFile2);
            string[] asArray = file1ExceptFile2.ToArray();
            next = asArray;
        }
        private static IEnumerable<string> ExceptSortedInputsClean(IEnumerable<string> inputSequence, IEnumerable<string> exceptSequence)
        {
            IEnumerator<string> exceptEnumerator = exceptSequence.GetEnumerator();
            bool exceptStillHasElements = exceptEnumerator.MoveNext();
            IEnumerator<string> inputEnumerator = inputSequence.GetEnumerator();
            bool inputStillHasElements = inputEnumerator.MoveNext();
            while (inputStillHasElements)
            {
                if (exceptStillHasElements == false)
                {
                    // since we exhausted the except sequence, we know we can safely return any input elements
                    yield return inputEnumerator.Current;
                    inputStillHasElements = inputEnumerator.MoveNext();
                    continue;
                }
                // need to compare to see which operation to perform
                switch (String.Compare(inputEnumerator.Current, exceptEnumerator.Current))
                {
                    case -1:
                        // except sequence is already later, so we can safely return this
                        yield return inputEnumerator.Current;
                        inputStillHasElements = inputEnumerator.MoveNext();
                        break;
                    case 0:
                        // except sequence has a match, so we can safely skip this
                        inputEnumerator.MoveNext();
                        break;
                    case 1:
                        // except sequence is behind - we need to move it forward
                        exceptStillHasElements = exceptEnumerator.MoveNext();
                        break;
                }
            }
        }
        private static void ManningsCleanInterleaved()
        {
            IEnumerable<string> wordsFromFile1 = File.ReadLines(filename1);
            IEnumerable<string> wordsFromFile2 = File.ReadLines(filename2);
            IEnumerable<string> file1ExceptFile2 = ExceptSortedInputsClean(wordsFromFile1, wordsFromFile2);
            string[] asArray = file1ExceptFile2.ToArray();
            next = asArray;
        }
        private static void UnintelligentParallelDicto()
        {
            Thread.Sleep(1000);
        }
    }
 
