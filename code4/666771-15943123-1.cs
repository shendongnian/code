    private static readonly Object _arbitraryUrlLock = new Object();
    private static String _arbitraryUrl;
    
    public void Application_BeginRequest() {
        lock( _arbitraryUrlLock ) 
            if( _arbitraryUrl == null ) 
                _arbitraryUrl = HttpContext.Current.Request.Url.ToString();
    }
