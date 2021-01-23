       [OutputCache(Duration=3600, VaryByParam="none", Location=OutputCacheLocation.Client, NoStore=true)]
       public string GetName()
       {
             return "Hi " + User.Identity.Name;
       }
