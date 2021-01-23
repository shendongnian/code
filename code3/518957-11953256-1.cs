    private static IEnumerable<IndexEntry> GetIndexEntries(RootWord rootWord, string indexName)
    {
        var indexKeyValues =
            new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("term", rootWord.Term)
                };
        return new[]
                   {
                       new IndexEntry
                           {
                               Name = indexName,
                               KeyValues = indexKeyValues.Where(v => v.Value != null)
                           }
                   };
    }
