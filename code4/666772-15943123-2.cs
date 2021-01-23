    private static readonly Object _arbitraryUrlLock = new Object();
    private static volatile String _arbitraryUrl;
    
    public void Application_BeginRequest() {
        if( _arbitraryUrl == null ) 
            lock( _arbitraryUrlLock )
                if( _arbitraryUrl == null ) 
                    _arbitraryUrl = HttpContext.Current.Request.Url.ToString();
    }
