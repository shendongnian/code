    DataTable users = new DataTable();
    
    if (Cache["users"] == null)
    {
        // users = getUsers(customer);
       Cache.Add(“users”, users, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 60, 0), System.Web.Caching.CacheItemPriority.Default, null);
    }
     else
    {
        sers = (DataTable)Cache["users"];
    }
