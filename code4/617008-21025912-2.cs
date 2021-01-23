    /// <summary>
    /// Method to change DataPager URLs so they keep the URL Rewriting pattern
    /// Code adapted from http://weblogs.asp.net/anasghanem/archive/2009/10/08/programmatically-modifying-the-hyperlinks-in-the-datapager-control.aspx
    /// </summary>
    /// <param name="pager">The DataPager for which we modify the URLS</param>    
    static public void SetDataPagerUrls(DataPager pager)
    {
        string queryStringField = pager.QueryStringField;
    
        //Rewrited URL is in Page.Request.RawUrl
        string rawUrl = pager.Page.Request.RawUrl;
        //Get the value of the current page =>  abc.aspx?[queryStringField]=[X]
        string currentQueryStringValue = pager.Page.Request[queryStringField];
    
        //Remove the current page querystring from the URL
        rawUrl = rawUrl.Replace(queryStringField + "=" + currentQueryStringValue,"");        
        //Remove the trailing "?" or "&"        
        if (rawUrl.EndsWith("?") || rawUrl.EndsWith("&"))
        {
            rawUrl = rawUrl.Substring(0, rawUrl.Length - 1);
        }
    
        string queryStringValue = "";    
        //Loop through the DataPager HyperLinks to modify the NavigateUrl   
        foreach (DataPagerFieldItem Pitem in pager.Controls)
        {
            foreach (Control c in Pitem.Controls)
            {
                if (c is HyperLink)
                {
                    HyperLink link = c as HyperLink;
                    //Get the page value for the link NavigateUrl
                    queryStringValue = GetQueryStringNumericValue(queryStringField, link.NavigateUrl);
    
                    //Set the new URL
                    link.NavigateUrl = rawUrl;
                    if (link.NavigateUrl.Contains("?"))
                    {
                         link.NavigateUrl += "&";
                    }
                    else
                    {
                         link.NavigateUrl += "?";
                    }
                    link.NavigateUrl += queryStringField + "=" + queryStringValue;                    
                }
            }
        } 
    }
    
    /// <summary>
    /// Gets a numeric value of a querystring parameter in a URL
    /// </summary>
    /// <param name="queryStringField">The name of the querystring field</param>
    /// <param name="url">The URL in which the querystring value must be found</param>
    /// <returns></returns>
    static protected string GetQueryStringNumericValue(string queryStringField, string url)
    {
        string returnValue = "";
        //Regular expression will match value like "p=9" in a url like "abc.aspx?p=9" or "abc.aspx?a=1&p=9&..."
        string pat = queryStringField + @"=[0-9]+";
        Regex r = new Regex(pat, RegexOptions.IgnoreCase);
        MatchCollection m = r.Matches(url);
        if (m.Count > 0)
        {
            //Remove the "[parameter]=" to keep only the value
            returnValue = m[0].Value.Replace(queryStringField + "=", "");
        }
        return returnValue;
    }
