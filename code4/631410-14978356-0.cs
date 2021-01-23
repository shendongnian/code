    Dictionary<string, string> test = new Dictionary<string, string>();
    int dictionaryLength = test.Count();
    
    for (int i = 0; i < dictionaryLength; i++)
    {
        test[test.ElementAt(i).Key] = "Some new content";
    }
