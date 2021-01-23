    string[] stopWords = new string[]
    {
        "string1",
        "string2"
    }
    using(StreamReader sr = File.OpenText(path))
    {
        while ((stringToRemove = sr.ReadLine()) != null)
        {
            if (!stopWords.Any(s => stringToRemove.Contains(s))
            {
                emptyreplace += stringToRemove + Environment.NewLine;
            }
        }
        ...
    }
