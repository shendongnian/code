        class Program
    {
        static void Main(string[] args)
        {
            //Load your string here - I got war and peace from project guttenburg (http://www.gutenberg.org/ebooks/2600.txt.utf-8) and loaded twice to give 1.2 Million words
            List<string> loaded = File.ReadAllText(@"D:\Temp\2600.txt").Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> items = new List<string>();
            items.AddRange(loaded);
            items.AddRange(loaded);
            Console.WriteLine("Loaded {0} words", items.Count);
            Stopwatch sw = new Stopwatch();
            List<string> WordsUnwanted = new List<string> { "Hell", "Heaven", "and", "or", "big", "the", "when", "ur", "cat" };
            StringBuilder regexBuilder = new StringBuilder("(?i)(");
            foreach (string s in WordsUnwanted)
            {
                regexBuilder.Append(s);
                regexBuilder.Append("|");
            }
            regexBuilder.Replace("|", ")", regexBuilder.Length - 1, 1);
            string regularExpression = regexBuilder.ToString();
            Console.WriteLine(regularExpression);
            List<string> words = null;
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Enter test type - 1, 2, 3, 4 or Q to quit");
                ConsoleKeyInfo testType = Console.ReadKey();
                switch (testType.Key)
                {
                    case ConsoleKey.D1:
                        sw.Reset();
                        sw.Start();
                        words = items
                            .Distinct()
                            .AsParallel()
                            .Where(x => !WordContains(x, WordsUnwanted)).ToList();
                        sw.Stop();
                        Console.WriteLine("Parallel (original) process took {0}ms and found {1} matching words", sw.ElapsedMilliseconds, words.Count);
                        words = null;
                        break;
                    case ConsoleKey.D2:
                        sw.Reset();
                        sw.Start();
                        words = items
                            .Distinct()
                            .Where(x => !WordContains(x, WordsUnwanted)).ToList();
                        sw.Stop();
                        Console.WriteLine("Non-Parallel (original) process took {0}ms and found {1} matching words", sw.ElapsedMilliseconds, words.Count);
                        words = null;
                        break;
                    case ConsoleKey.D3:
                        sw.Reset();
                        sw.Start();
                        words = items
                            .Distinct()
                            .AsParallel()
                            .Where(x => !Regex.IsMatch(x, regularExpression)).ToList();
                        sw.Stop();
                        Console.WriteLine("Non-Compiled regex (parallel) Process took {0}ms and found {1} matching words", sw.ElapsedMilliseconds, words.Count);
                        words = null;
                        break;
                    case ConsoleKey.D4:
                        sw.Reset();
                        sw.Start();
                        words = items
                            .Distinct()
                            .Where(x => !Regex.IsMatch(x, regularExpression)).ToList();
                        sw.Stop();
                        Console.WriteLine("Non-Compiled regex (non-parallel) Process took {0}ms and found {1} matching words", sw.ElapsedMilliseconds, words.Count);
                        words = null;
                        break;
                    case ConsoleKey.Q:
                        loop = false;
                        break;
                    default:
                        continue;
                }
            }
        }
        public static bool WordContains(string word, List<string> words)
        {
            for (int i = 0; i < words.Count(); i++)
            {
                //Found that this was a bit fater and also lets you check the casing...!
                //if (word.Contains(words[i]))
                if (word.IndexOf(words[i], StringComparison.InvariantCultureIgnoreCase) >= 0)
                    return true;
            }
            return false;
        }
    }
 
