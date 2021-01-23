    public void InsertIntIntoCache( string key, int value )
    {
       HttpContext.Current.Cache.Insert( key, value );
    }
    public int GetIntCacheValue( string key )
    {
       return (int)HttpContext.Current.Cache[key];
    }
    int test = 123;
    InsertIntIntoCache( "key", test );
    test = GetIntCacheValue( "key" );
