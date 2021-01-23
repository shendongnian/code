    public bool allWordsContained(string input, string keyword)
    {
        bool result = true;
        string[] words = keyword.Split(' ');
        foreach (var word in words)
        {
            if (!input.Contains(word))
                result = false;
        }
        return result;
    }
    public bool atLeastOneWordContained(string input, string keyword)
    {
        bool result = false;
        string[] words = keyword.Split(' ');
        foreach (var word in words)
        {
            if (input.Contains(word))
                result = true;
        }
        return result;
    }
