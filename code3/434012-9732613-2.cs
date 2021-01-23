    class Program
    {
        static void Main(string[] args)
        {
            var test = new Synonmys(Tuple.Create("ca", "ca"),
                                    Tuple.Create("ca", "california"),
                                    Tuple.Create("ln", "ln"),
                                    Tuple.Create("ln", "lane"));
    
            foreach (var comb in test.GetCombinations("2 ln ca"))
                Console.WriteLine("Combination: " + comb);
        }
    }
    
    class Synonmys
    {
        private Dictionary<string, IEnumerable<string>> synonyms;
    
        public Synonmys(params Tuple<string, string>[] syns )
        {
            synonyms = syns.GroupBy(s => s.Item1).ToDictionary(g => g.Key, g => g.Select(kvp => kvp.Item2));
        }
    
        private IEnumerable<string> GetSynonmys(string word)
        {
            return synonyms.ContainsKey(word) ? synonyms[word] : new[]{word};
        }
    
        private string[] GetWords(string text)
        {
            return text.Split(new[]{' '}); // add more seperators if you need
        }
    
        private IEnumerable<string> GetCombinations(string[] words, int lookAt = 0)
        {
            if (lookAt >= words.Length) return new[]{""};
    
            var currentWord = words[lookAt];
            var synonymsForCurrentWord = GetSynonmys(currentWord);
            var combinationsForRest = GetCombinations(words, lookAt + 1);
    
            return synonymsForCurrentWord.SelectMany(synonym => combinationsForRest.Select(rest => synonym + " " + rest));
        }
    
        public IEnumerable<string> GetCombinations(string text)
        {
            return GetCombinations(GetWords(text));
        }
    
    }
