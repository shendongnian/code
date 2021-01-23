    static IQueryable<Stat> DictionaryFilter(IQueryable<Stat> source,
        Dictionary<GetSourcesNameResult, bool> sourceDictionary)
    {
        var words = (from word in sourceDictionary
                     where word.Value
                     select word.Key.SourceName).ToArray();
        switch (words.Length)
        {
            case 0:
                return source.Where(x => false);
            case 1:
                string word = words[0];
                return source.Where(x => x.SourceName == word);
            case 2:
                string word0 = words[0], word1 = words[1];
                return source.Where(
                      x => x.SourceName == word0 || x.SourceName == word1);
            default:
                return source.Where(x => words.Contains(x.SourceName));
        }
    }
