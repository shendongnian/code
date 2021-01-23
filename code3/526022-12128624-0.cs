    protected IEnumerable<string> GetErrorsFromModelState()
    {
        var exceptions = ModelState.SelectMany(x => x.Value.Errors
            .Select(error => error.Exception));
        var errors =  ModelState.SelectMany(x => x.Value.Errors
            .Select(error => error.ErrorMessage));
        
        return exceptions.Union(errors);
    }
