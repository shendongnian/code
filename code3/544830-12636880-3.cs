    var bLookupSet = new HashSet(b.Select(b =>
                       new { 
                           Column1 = b.Column1.ToLower(), 
                           Column2 = b.Column2.ToLower(),
                           Column3 = b.Column3.ToLower()
                           }));
    var resultList = a.Where(a => bLookupSet.Contains(
                       new { 
                           Column1 = a.Column1.ToLower(), 
                           Column2 = a.Column2.ToLower(),
                           Column3 = a.Column3.ToLower()
                           })).ToList();
