    public static Collection<CProductMakesProps> GetCachedSmartPhoneMake(HttpContext context)
    {
        if (!context.Cache.ContainsKey("SmartPhoneMake") || context.Cache["SmartPhoneMake"] == null)
        {
            context.Cache.Insert("SmartPhoneMake"
                                 , new CModelRestrictionLogic().GetTopMakes()
                                 , null
                                 , DateTime.Now.AddHours(Int32.Parse(ConfigurationManager.AppSettings["MakeCacheTime"]))
                                 , Cache.NoSlidingExpiration);
        }
    
        return context.Cache["SmartPhoneMake"] as Collection<CProductMakesProps>;
    }
