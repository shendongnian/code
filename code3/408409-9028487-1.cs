        public static IEnumerable<char> SplitItOut(IEnumerable<string> words)
        {
            var taskResults = new ConcurrentBag<char[]>();
            Parallel.ForEach(words, word => taskResults.Add(GetCharacters(word)));
            return taskResults.SelectMany(wordResult => wordResult);
        }
