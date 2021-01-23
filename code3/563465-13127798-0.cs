    protected override void OnException(ExceptionContext contextFilter)
    {
        // Here you test if the exception is what you are expecting
        if (contextFilter.Exception is YourExpectedException)
        {
            // Switch to an error view
            ...
        }
        //Otherwise, let the base OnException method handle it.
        base.OnException(contextFilter);
    }
