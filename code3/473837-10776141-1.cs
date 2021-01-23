    protected void Application_BeginRequest(object sender, EventArgs e){
        ContextProvider.OpenNew();
    }
    
    protected void Application_EndRequest(object sender, EventArgs e){
        ContextProvider.CloseCurrent();
    }
    
