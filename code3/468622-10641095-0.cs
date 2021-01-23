    FileSystemWatcher fsWatcher = new FileSystemWatcher();
    fsWatcher.Created += new FileSystemEventHandler( fsWatcher_Created );
    private void fsWatcher_Created( object sender, FileSystemEventArgs e )
    {
        RaiseFileFoundEvent( e.FullPath );
        while ( !TestOpen( e.FullPath ) ) ;
        RaiseFileCopyDoneEvent( e.FullPath );
    }
    private bool TestOpen( string filename )
    {
        try
        {
            FileStream fs = new FileStream( filename, FileMode.Open, 
                FileAccess.Write, FileShare.None );
            fs.Close();
            return true;
        }
        catch ( Exception )
        {
            return false;
        }
    }
    private void RaiseFileFoundEvent( string fullPath )
    {
        // a file is found, but the copy is not guaranteed to be finished yet.
    }
    private void RaiseFileCopyDoneEvent( string fullPath )
    {
        // the file is found, and we know the copy is done.
    }
