    void Application_Start(object sender, EventArgs e)
    {
        var refreshMinutes = 60;
        AddTask("UndateInfo", 
                (int)TimeSpan.FromMinutes(refreshMinutes).TotalSeconds);
    }
    private void AddTask(string name, int seconds)
    {
        OnCacheRemove = new CacheItemRemovedCallback(CacheItemRemoved);
        HttpRuntime.Cache.Insert(name, seconds, null,
            DateTime.Now.AddSeconds(seconds), Cache.NoSlidingExpiration,
            CacheItemPriority.NotRemovable, OnCacheRemove);
    }
    public void CacheItemRemoved(string key, object v, CacheItemRemovedReason r)
    {
        if ("UndateInfo".Equals(key))
        {
            try
            {
                new SearchService().UpdateInfo();
            }
            catch (Exception ex)
            {
                logger.Error("UpdateInfo threw an exception: {0} {1}", ex.Message, ex.StackTrace);
            }
        }
        AddTask(key, Convert.ToInt32(v));
    }
