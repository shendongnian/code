    public static void QueryTerms(IGraphClient gc, string query)
    {
        var result = gc.QueryIndex<RootWord>("synonyms", IndexFor.Node, "term:" + query).ToList();
        if (result.Any())
            foreach (var node in result)
                Console.WriteLine("node: {0} -> {1}", node.Reference.Id, node.Data.Term);
        else
            Console.WriteLine("No results...");
    }
