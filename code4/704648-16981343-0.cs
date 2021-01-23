    protected void Application_Error(Object sender, EventArgs e)
    {
        HttpException ex = (HttpException)Server.GetLastError();
        int httpCode = ex.GetHttpCode();
        if (httpCode == 404)
        {
            //do 404 code work here
        }
        if (httpCode == ???)
        {
            //do ??? code work here
        }
    }
