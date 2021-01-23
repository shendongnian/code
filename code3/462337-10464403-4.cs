    private List<string> GenerateTerms(string[] docs)
    {
        return docs.SelectMany(doc => ProcessDocument(doc)).Distinct().ToList();
    }
    private IEnumerable<string> ProcessDocument(string doc)
    {
        return doc.Split(' ')
                  .GroupBy(word => word)
                  .OrderByDescending(g => g.Count())
                  .Select(g => g.Key)
                  .Take(10000);
    }
