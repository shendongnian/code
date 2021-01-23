    application.Response.Clear();
    application.Response.Status = Constants.HttpServerError;
    application.Response.TrySkipIisCustomErrors = true;
    LogApplicationException(application.Response, exception);
    try
    {
        WriteViewResponse(exception);
    }
    // now we're in trouble. lets be as graceful as possible.
    catch (Exception exceptionWritingView)
    {
        // Example on how to nest exceptions.
        throw MyException("Error message", exceptionWritingView);
    }
    finally
    {
        application.Server.ClearError();
    }
