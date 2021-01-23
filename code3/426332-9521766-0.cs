    SPSite oSiteCollection = SPContext.Current.Site;
    SPWebCollection collWebsite = oSiteCollection.AllWebs;
    
    for (int i = 0; i < collWebsite.Count; i++)
    {
        using (SPWeb oWebsite = collWebsite[i])
        {
            SPListCollection collList = oWebsite.Lists;
    
            for (int j = 0; j < collList.Count; j++)
            {
                Label1.Text += SPEncode.HtmlEncode(collWebsite[i].Title) + "   "
                    + SPEncode.HtmlEncode(collList[j].Title) + "<BR>";
            }
        }
