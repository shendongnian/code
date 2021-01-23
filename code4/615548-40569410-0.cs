    private static SiteMetadataCacheItem GetCachedItem()
    {
          TenantService TS = new TenantService(); // my service datacontext
          var CachedItem = Task.Run(async ()=> 
                   await TS.GetTenantDataAsync(TenantIdValue)
          ).Result; // dont deadlock anymore
    }
