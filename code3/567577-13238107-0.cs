            var results = result.ToArray()
                  .GroupBy(c => c, new CompanyNameIgnoringSpaces())
                  .Select(g => new LeadGridViewModel
                  {
                      LeadId = g.First().LeadId,
                      Qty = g.Count(),
                      CompanyName = g.Key.CompanyName,
                  }).OrderByDescending(x => x.Qty).ThenBy(x => x.CompanyName).ToList();
     2. ToLookup()
            var results = result
                  .ToLookup(c => c, new CompanyNameIgnoringSpaces())
                  .Select(g => new LeadGridViewModel
                  {
                      LeadId = g.First().LeadId,
                      Qty = g.Count(),
                      CompanyName = g.Key.CompanyName,
                  }).OrderByDescending(x => x.Qty).ThenBy(x => x.CompanyName).ToList();
     3. Stream the results
            public static class EnumerableExtensions
            {
                public IEnumerable<T> ToResultStream<T>(this IEnumerable<T> underlying)
                {
                     //start query up to this point
                     var enumerator = underlying.GetEnumerator();
                     while(enumerator.MoveNext())
                     {
                          yield return enumerator.Current;
                     }
                }
            }
            var results = result.ToResultStream()
                  .GroupBy(c => c, new CompanyNameIgnoringSpaces())
                  .Select(g => new LeadGridViewModel
                  {
                      LeadId = g.First().LeadId,
                      Qty = g.Count(),
                      CompanyName = g.Key.CompanyName,
                  }).OrderByDescending(x => x.Qty).ThenBy(x => x.CompanyName).ToList();
    Note: Most variants of sql have a replace function so you could potentially hard-code the replaces into an expression and hence do this on the server side. If you wanted it to be reusable you would want something like the following:
        private static Expression<Func<LeadGridViewModel,String>> leadGridTransform = 
            (lead) => lead.CompanyName == null ? "", lead.CompanyName.Replace(' ','\0').Replace.... ;
    Which you would then be able to use in Queryable expressions:
        var results = result.GroupBy(leadGridTransform)....
    The ternary operator was used here as it avoids costly server side coalesce operations.
