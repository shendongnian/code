    var statusCode = 500;
    var ex = Server.GetLastError();
    if (ex != null)
    {
        var httpEx = ex as HttpException;
        if (httpEx != null)
        {
            // HttpAntiForgeryException is HttpException and gets received here,
            // so its statusCode is what I get here.
            statusCode = httpEx.GetHttpCode();
        }
    }
    // Some logging logic then
    if (!Context.IsCustomErrorEnabled)
        return;
    Response.ClearContent();
    Response.StatusCode = statusCode;
    // Rendering custom error page in response then
    Server.ClearError();
  
