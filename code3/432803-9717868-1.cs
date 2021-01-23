    protected void Application_Error(object sender, EventArgs e)
    {
        if(Context.Request.IsLocal)
        {
            //do stuff
        }
    } 
