    namespace StackOverflow.Demos
    {
        class Program
        {
            const string OutputFormat = "{0}: {1}";
            public static void Main(string[] args)
            {
                new Program("Another great story and another great adventure.");
                Console.WriteLine("Done");
                Console.ReadKey();
            }
            public Program(string userInput)
            {
                WordCounter myWordCounter = new WordCounter(userInput);
                Console.WriteLine("\n**Alphabetical**");
                foreach (KeyValuePair<string, int> wordInfo in myWordCounter.GetWordCountByWordAlphabeticalDesc())
                {
                    Console.WriteLine(string.Format(OutputFormat,wordInfo.Key, wordInfo.Value));
                }
                Console.WriteLine("\n**Alphabetical Desc**");
                foreach (KeyValuePair<string, int> wordInfo in myWordCounter.GetWordCountByWordAlphabeticalDesc())
                {
                    Console.WriteLine(string.Format(OutputFormat, wordInfo.Key, wordInfo.Value));
                }
                Console.WriteLine("\n**Frequency Desc**");
                foreach (KeyValuePair<string, int> wordInfo in myWordCounter.GetWordCountByFrequency())
                {
                    Console.WriteLine(string.Format(OutputFormat, wordInfo.Key, wordInfo.Value));
                }
            }
             
        }
        public class WordCounter
        {
            string sentance;
            IEnumerable<IGrouping<string, int>> words;
            public WordCounter(string sentance)
            {
                this.sentance = sentance;
                GetWords();
            }
            void GetWords()
            {
                this.words = Regex.Split(this.sentance, @"\W+").GroupBy(word => word.ToLowerInvariant(), word => 1);
            }
            public IEnumerable<KeyValuePair<string, int>> GetWordCountByWordAlphabetical()
            {
                return this.words.OrderBy(word => word.Key).Select(wordInfo => new KeyValuePair<string,int>(wordInfo.Key, wordInfo.Count()));
            }
            public IEnumerable<KeyValuePair<string, int>> GetWordCountByWordAlphabeticalDesc()
            {
                return this.words.OrderByDescending(word => word.Key).Select(wordInfo => new KeyValuePair<string, int>(wordInfo.Key, wordInfo.Count()));
            }
            public IEnumerable<KeyValuePair<string, int>> GetWordCountByFrequency()
            {
                return this.words.OrderByDescending(word => word.Count()).Select(wordInfo => new KeyValuePair<string, int>(wordInfo.Key, wordInfo.Count()));
            }
        }
    }
    
