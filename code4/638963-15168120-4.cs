    protected void Application_Error()
    {
        Exception unhandledException = Server.GetLastError();
        HttpException httpException = unhandledException as HttpException;
        if (httpException == null)
        {
            Exception innerException = unhandledException.InnerException;
            httpException = innerException as HttpException;
        }
        if (httpException != null)
        {
            int httpCode = httpException.GetHttpCode();
            switch (httpCode)
            {
                case (int)HttpStatusCode.Unauthorized:
                    Response.Redirect("/Http/Error401");
                    break;
                // TODO: don't forget that here you have many other status codes to test 
                // and handle in addition to 401.
            }
            else
            {
                // It was not an HttpException. This will be executed for your test action.
                // Here you should log and handle this case. Use the unhandledException instance here
            }
        }
    }
