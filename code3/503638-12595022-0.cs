    [OutputCache(Duration = 10, VaryByParam = "none", Location = OutputCacheLocation.Any)]
    public string Get()
    {
         HttpContext.Current.Response.Cache.SetOmitVaryStar(true);
          return System.DateTime.Now.ToString();
    }
   
