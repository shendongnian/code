    public IEnumerable KeyValuePair<string, object> CacheItems
    {
        get
        { // we are not exposing the raw dictionary now
            foreach(var item in cacheItems) yield return item;
        }
    }
    public object this[string key] { get { return cacheItems[key]; } }
