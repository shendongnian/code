    IEnumerator en = mFile.Map.Mappings.GetEnumerator();
    
    while (en.MoveNext())
    {
    	SiteMapping sm = (SiteMapping) en.Current;
        if (String.IsNullOrEmpty(sm.SiteNumber))
        {
          HashSiteMapping.Add(String.Empty, sm.LocationNumber);
        }
        else
        {
          HashSiteMapping.Add(sm.SiteNumber, sm.LocationNumber);
        }
    }
