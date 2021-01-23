    var bLookupSet = new HashSet(b.Select(b =>
                       new { 
                           Column1 = b.Column1, 
                           Column2 = b.Column2,
                           Column3 = b.Column3
                           }));
    var result = a.Where(a => bLookupSet.Contains(
                       new { 
                           Column1 = a.Column1, 
                           Column2 = a.Column2,
                           Column3 = a.Column3
                           }));
