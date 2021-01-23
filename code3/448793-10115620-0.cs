    public override Load() 
    { 
        Bind<ISearchService>().To<SolrSearchService>().When(r => ShouldUseSolr());
        Bind<ISearchService>().To<SqlSearchService>().When(r => !ShouldUseSolr());
    }
    private static ShouldUseSolr()
    {
        // Should cache and only do this at an interval.  
        ConfigurationManager.RefreshSection("appSettings");  
        var index = ConfigurationManager.AppSettings["UseSolr"] as string;  
  
        bool result;
        bool.TryParse(index, out result);  
        return result;
    }
