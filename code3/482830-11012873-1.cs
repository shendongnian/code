    protected void Application_End(
    	Object sender, EventArgs e)
    {
    	FileSystemWatcher fsw =
    		(FileSystemWatcher
    		)Application[“myfsw”];
    	Application.Remove( “myfsw” );
    	fsw.Dispose();
    }
