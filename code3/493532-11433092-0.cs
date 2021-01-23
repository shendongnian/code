    protected void Application_Start()
    {
        PreSendRequestHeaders += new EventHandler(OnPreSendRequestHeaders);
    }
    
    protected void OnPreSendRequestHeaders(object sender, EventArgs e)
    {
        // should work now
    }
