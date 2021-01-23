    public void LoadDllFile( string dllfolder, string libname ) {
        var currentpath = new StringBuilder(255);
        UnsafeNativeMethods.GetDllDirectory( currentpath.Length, currentpath );
        
        // use new path
        SetDllDirectory( dllfolder );
        LoadLibrary( libname );
        // restore old path
        SetDllDirectory( currentpath );
    }
