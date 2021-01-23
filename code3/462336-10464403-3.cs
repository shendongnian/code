    private List<string> GenerateTerms(string[] docs)
    {
         var result = docs
             .SelectMany(doc => doc.Split(' ')
                                   .GroupBy(word => word)
                                   .OrderByDescending(g => g.Count())
                                   .Select(g => g.Key)
                                   .Take(20000))
             .Distinct()
             .ToList();   
         return result;
    }
