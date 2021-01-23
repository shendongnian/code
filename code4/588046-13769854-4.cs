    //include the namespace
    using System.Globalization;
    private string FilterUrl(string url)
    {
        // ccreate a Comparer object.
        CompareInfo myCompare = CultureInfo.InvariantCulture.CompareInfo;
    
        // find the 'www.' on the url parameter ignoring the case.
        int position = myCompare.IndexOf(url, "www.", CompareOptions.IgnoreCase);
    
        // check if exists 'www.'  on the string.
        if (position > -1)
            url = url.Remove(position -1, 5);
                
        //if you want to remove http://, https://, ftp://.. keep this line
        url = url.Replace("http://", string.Empty).Replace("https://", string.Empty).Replace("ftp://", string.Empty);
    
        return url;
    }   
