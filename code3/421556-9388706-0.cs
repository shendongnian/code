    class WordSet {
        public WordSet(IEnumerable<string> words) {
            m_OriginalWords = new SortedSet<string>(words);
            m_ReverseWords = new SortedSet<string>(words.Select(ReverseString));
        }
        /// <summary>
        ///     Finds all words that start with given prefix.
        /// </summary>
        public IEnumerable<string> FindPrefix(string prefix) {
            return FindImp(m_OriginalWords, prefix);
        }
        /// <summary>
        ///     Finds all words that end with the given suffix.
        /// </summary>
        public IEnumerable<string> FindSuffix(string suffix) {
            return FindImp(m_ReverseWords, ReverseString(suffix)).Select(ReverseString);
        }
        static IEnumerable<string> FindImp(SortedSet<string> word_set, string s) {
            if (s.CompareTo(word_set.Max) <= 0) {
                foreach (string word in word_set.GetViewBetween(s, word_set.Max)) {
                    if (!word.StartsWith(s))
                        break;
                    yield return word;
                }
            }
        }
        static string ReverseString(string src) {
            return new string(src.Reverse().ToArray());
        }
        readonly SortedSet<string> m_OriginalWords;
        readonly SortedSet<string> m_ReverseWords;
    }
    class Program {
        static void TestImp(string s, IEnumerable<string> words) {
            Console.Write(s);
            foreach (var word in words) {
                Console.Write('\t');
                Console.Write(word);
            }
            Console.WriteLine();
        }
        static void TestPrefix(WordSet word_set, string prefix) {
            TestImp(prefix, word_set.FindPrefix(prefix));
        }
        static void TestSuffix(WordSet word_set, string suffix) {
            TestImp(suffix, word_set.FindSuffix(suffix));
        }
        static void Main(string[] args) {
            var word_set = new WordSet(
                new[] {
                    "a",
                    "b",
                    "ba",
                    "baa",
                    "bab",
                    "bba",
                    "bbb",
                    "bbc",
                }
            );
            Console.WriteLine("Prefixes:");
            TestPrefix(word_set, "a");
            TestPrefix(word_set, "b");
            TestPrefix(word_set, "ba");
            TestPrefix(word_set, "bb");
            TestPrefix(word_set, "bc");
            Console.WriteLine("\nSuffixes:");
            TestSuffix(word_set, "a");
            TestSuffix(word_set, "b");
            TestSuffix(word_set, "ba");
            TestSuffix(word_set, "bb");
            TestSuffix(word_set, "bc");
        }
    }
