    public static IEnumerable<string> Search (this SearchCore s, IQuery q)
    {
        //after you get query result
        CacheStoreEventArgs cs = new CacheStoreEventArgs(queryresultvariablehere);
        //and call your method now with the instance of your derived eventargs class
        OnQuery(cs);
    }
    
    public virtual void OnQuery (CacheStoreEventArgs e)
    {
         try
         {
            EventHandler<CacheStoreEventArgs> temp = AddToCache
            if( temp != null)
                  temp(this,e);
         }
         catch(Exception ex) 
         {
            //exception handling
         }
    }
