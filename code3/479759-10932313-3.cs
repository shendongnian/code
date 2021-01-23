    IQueryable<T> RestOfMethod<T>(IQueryable<T> rData)
    {
      var fData = Enumerable.Empty<T>().AsQueryable(); // or = rData;
    
      if(x)
        fData = fData.Concat(rData.Where(u => ...));
      if(y)
        fData = fData.Concat(rData.Where(u => ...));
    
      return fData;
    }
    
    // original code location
    var rData = some query;
    var fData = RestOfMethod(rData);
