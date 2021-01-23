    var dictionary = new Dictionary<int, Lookup<string, string>>();
    for (int i = 1; i < maxWordLength; i++)
    {
        // get all words with i or more letters
        dictionary.Add(i, words.ToLookup(w => w.Substring(i)));
    }
