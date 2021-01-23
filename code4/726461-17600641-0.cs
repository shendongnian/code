    DirectorySearcher dsr = new DirectorySearcher();
    dsr.SearchRoot = new DirectoryEntry(settings.Path, settings.Username, settings.Password, settings.AuthType);
    dsr.PageSize = 100;
    dsr.SizeLimit = 0;
    dsr.SearchScope = SearchScope.OneLevel;
    dsr.Filter = "(&(objectclass=user)(sn=UserLastName))";
    dsr.PropertiesToLoad.AddRange(new string[] { "sn", "givenName" });
    using (SearchResultCollection src = dsr.FindAll())
    {
    	foreach (SearchResult sr in src)
    	{
    		string propName = lp.Name;
    		ResultPropertyValueCollection rpvc = sr.Properties[propName];
    		string val = (string)rpvc[0];
    	}
    }
