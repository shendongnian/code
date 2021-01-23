    public IEnumerable<string> GetErrors(Exception ex)
    {
        ...
        var results = new List<string>() { ex.Message };
        var innerEx = ex.InnerException;
        while (innerEx != null) 
        {
            results.Add(innerEx.Message);
            innerEx = innerEx.InnerException;
        }
        return results;
    }
