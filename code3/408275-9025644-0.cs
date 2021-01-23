    public static DataType GetData( this Foo obj )
    {
        DataType retVal;
        // this sample doesn't show any locking, i.e. it is not thread safe
        // if cache manager contains data return from there
        if( CacheManager.HasData( obj.UniqueId ) )
        {
             retVal = CacheManager.GetData( obj.UniqueId );
        }    
        else
        {
             // otherwise invoke a method on obj and add to cache
             retVal = obj.GetData();
             CacheManager.Add( obj.UniqueId, retVal );
        }
        return retVal;
    }
