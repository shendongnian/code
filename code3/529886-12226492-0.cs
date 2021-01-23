    protected IEnumerable<string> GetErrorsFromModelState()
    {        
        var exceptions = ModelState.SelectMany(x => x.Value.Errors
                .Where(error => (error != null) && 
                                (error.Exeception != null) &&
                                (error.Exeception.Message != null))
                .Select(error => error.Exception.Message));
        var errors = ModelState.SelectMany(x => x.Value.Errors
                .Where(error => (error != null) && 
                                (error.ErrorMessage != null))
                .Select(error => error.ErrorMessage));
        return exceptions.Union(errors);
    }
