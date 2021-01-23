    public static void AddNodeToDb(IGraphClient graphClient, string index, RootWord word, RootWord synonym)
    {
        if (!graphClient.CheckIndexExists(index, IndexFor.Node))
        {
            var configuration = new IndexConfiguration { Provider = IndexProvider.lucene, Type = IndexType.fulltext };
            graphClient.CreateIndex(index, configuration, IndexFor.Node);
        }
        var wordReference = graphClient.Create(word, null, GetIndexEntries(word, index));
        var synonymReference = graphClient.Create(synonym, null, GetIndexEntries(synonym, index));
        graphClient.CreateRelationship(wordReference, new IsSynonym(synonymReference));
        Console.WriteLine("Word: {0}, Synonym: {1}", wordReference.Id, synonymReference.Id);
    }
