    public IDictionary<string, IEnumerable<string>> Analyze(string text)
    {
        var results = new Dictionary<string, IEnumerable<string>>();
   
        using (var hunspell = new Hunspell("Resources\\en_GB.aff", "Resources\\en_GB.dic"))
        {   
            string[] words = Regex.Split(text, @"\W+", RegexOptions.IgnoreCase);
            IEnumerable<string> misspelledWords = words.Where(word => !hunspell.Spell(word));
            foreach (string word in misspelledWords)
            {
                IEnumerable<string> suggestions = hunspell.Suggest(word);
                results.Add(word, suggestions);
            }
        }
        return results;
    }
