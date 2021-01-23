    dynamic dynamicResponse = response;
    IValidator validator = TryResolveValidator(response); // magic happens here
    
    // ... your error handling code ...
    public IValidator<T> TryResolveValidator<T>(T response)
    {
        return AppHost.TryResolve<IValidator<T>>();
    }
