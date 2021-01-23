    public void getXMLContent()
    {
        getContent(parseXmlContent);
    }
    public void getContent(Func<string> parseContent)
    {
    
        Content = (String)HttpContext.Current.Cache[Path];
    
        if (Content == null)
        {                
            Content = parseContent();
    
            HttpContext.Current.Cache.Insert(
            key,
            Content,
            new CacheDependency(Path),
            Cache.NoAbsoluteExpiration,
            Cache.NoSlidingExpiration,    
            delegate(string key2, CacheItemUpdateReason reason, out object value, out CacheDependency dependency, out DateTime expiration, out TimeSpan slidingExpiration) {
                itemUpdateCallback(key2, reason, parseContent, out value, out dependency, out expiration, out slidingExpiration);
            }); 
        }
    }
    
    private void itemUpdateCallback(string key, CacheItemUpdateReason reason, Func<string> parseContent, out object value, out CacheDependency dependency, out DateTime exipriation, out TimeSpan slidingExpiration)
    {
        dependency = new CacheDependency(key);
        exipriation = Cache.NoAbsoluteExpiration;
        slidingExpiration = Cache.NoSlidingExpiration;
        value = parseContent();
    }
