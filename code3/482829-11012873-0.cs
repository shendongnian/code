    protected void Application_Start(
    	Object sender, EventArgs e)
    {
    	FileSystemWatcher fsw =
    		new FileSystemWatcher(
    		Server.MapPath( “.” ) );
    	Application.Add( “myfsw” , fsw );
    	// Add event handlers here
    	fsw.EnableRaisingEvents = true;
    }
