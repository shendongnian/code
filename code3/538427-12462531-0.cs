    private const string DummyCacheItemKey = "GagaGuguGigi";
    protected void Application_Start(Object sender, EventArgs e)
    {
        RegisterCacheEntry();
    }
 
    private bool RegisterCacheEntry()
    { 
        if( null != HttpContext.Current.Cache[ DummyCacheItemKey ] ) return false;
 
            HttpContext.Current.Cache.Add( DummyCacheItemKey, "Test", null, 
            DateTime.MaxValue, TimeSpan.FromMinutes(1), 
            CacheItemPriority.Normal,
            new CacheItemRemovedCallback( CacheItemRemovedCallback ) );
 
        return true;
    }
    public void CacheItemRemovedCallback( string key, 
            object value, CacheItemRemovedReason reason)
    {
        Debug.WriteLine("Cache item callback: " + DateTime.Now.ToString() );
        // send reminder emails here
        DoWork();
    }
