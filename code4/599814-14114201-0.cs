    //declare lock object for implementing critical section
    private static object docSummaryLock = new object();
    //this is the body of GetDocSummary method
    List<Doc> ds = (List<Doc>) System.Web.HttpContext.Current.Cache.Get("dSummary");
    if (ds != null) return ds;
    //summary not found in cache, computing the doc summary occurs in critical section
    lock (docSummaryLock)
    {
    	//there is possibility that another thread waited for obtaining the lock and the summary may be already in cache
    	ds = (List<Doc>) System.Web.HttpContext.Current.Cache.Get("dSummary");
    	if (ds != null) return ds;
    	
    	//compute the summary
    	ds = GetDocSummary();
    	System.Web.HttpContext.Current.Cache.Insert("dSummary", summaries, null, 
    	DateTime.Now.AddMinutes(15), System.Web.Caching.Cache.NoSlidingExpiration);
    	return ds;
    }
