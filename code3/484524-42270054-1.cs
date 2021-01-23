    public String RemoveQueryString( String rawUrl  , String keyName)
    {
        var currentURL_Split =  rawUrl.Split('&').ToList();
        currentURL_Split = currentURL_Split.Where(o => !o.ToLower().StartsWith(keyName.ToLower()+"=")).ToList();
        String New_RemovedKey = String.Join("&", currentURL_Split.ToArray()); 
        New_RemovedKey = New_RemovedKey.Replace("&&", "&");
        return New_RemovedKey;
    }
