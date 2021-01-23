    HttpException exception = Server.GetLastError() as HttpException;
    int errorCode = -1;
    
    if(exception != null)
    {
        errorCode = exception.GetHttpCode();
    }
    
    switch (errorCode)
    {
        case 404:
            // Redirect here
            break;
        default:
            // Redirect here
            break;
    }
