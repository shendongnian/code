    public List<string> UniqueWords(string[] setsOfWords)
    {
        List<string> words = new List<string>();
        foreach (var setOfWords in setsOfWords)
        {
            words.AddRange(setOfWords.Split(new char[] { ' ' }));
        }
        return words.Distinct().ToList();            
    }
