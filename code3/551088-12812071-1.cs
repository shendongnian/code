    // personalized cache item
    string personalCacheKey = string.Format("MyDataTable_{0}", (int)Session["UserID"]);
    DataTable myPersonalDataTable = (DataTable)Cache[personalCacheKey];
    
    if (myPersonalDataTable == null)
    {
        myPersonalDataTable = database.dosomething();
        Cache.Insert(personalCacheKey, myPersonalDataTable, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 30, 0)); // 30 minutes
    }
    // global (non user specific) cached item
    string globalCacheKey = "MyDataTable";
    DataTable globalDataTable = (DataTable)Cache[globalCacheKey];
    
    if (globalDataTable == null)
    {
        globalDataTable = database.dosomething();
        Cache.Insert(globalCacheKey, globalDataTable, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 30, 0)); // 30 minutes (again)
    }
