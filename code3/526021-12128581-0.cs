    protected IEnumerable<string> GetErrorsAndExceptionsFromModelState()
    {
        var errors = ModelState
                        .SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage)
                        .Union(x.Value.Errors.Select(error => error.Exception.Message)));
        return errors;
    }
