     SPSite topLevelSite = new SPSite("http://localhost");
     SPWeb spWebInstance = topLevelSite.OpenWeb();
     String siteTemplate = spWebInstance.WebTemplate;
     try
     {
    SharePointWebInstance.Webs.Add("the name", "name", "new site added",    (UInt32)System.Globalization.CultureInfo.CurrentCulture.LCID, siteTemplate, false, false);
      }
     catch(Exception ex)
     {
      //...
     }
     finally
     {
     topLevelSite.Close();
     SharePointWebInstance.Dispose();
     }
