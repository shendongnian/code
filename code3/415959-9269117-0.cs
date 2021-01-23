    void Application_Error(object sender, EventArgs e)
    {
        var exception = Server.GetLastError();
        if (exception is HttpException && exception.Message.Contains("A potentially dangerous Request.Path value was detected from the client"))
        {
            Server.ClearError();
        }
    }
