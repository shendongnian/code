    // Notice the lack of "Include". "Include" only states what should be returned
    // *with* the original type, and is not necessary if you only need to select the
    // individual property.
    var firstResults = Repository.Select<Table>()
                                 .Where(t => t.Column == null)
                                 .Select(t => t.Table2);
    							  
    var secondResults = Repository.Select<Table2>()
                                  .Where(t => t.Column2 == "Value");
    							  
    return firstResults.Union(secondResults);
