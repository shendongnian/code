    protected void Page_Load(object sender, EventArgs e)
    {
        this.CachePolicy.Dependency = new System.Web.Caching.CacheDependency(null, 
            new string[] { "KeyForThisUserControl"  });
        ...
    }
