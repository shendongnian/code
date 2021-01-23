    public T GetObjectFromKey(string key)
    {
        object returnObj = _cache.Get(key);
        if(returnObj.GetType() == typeof(T)) // may need to also check for inheritance
        {
             return (T) returnObj;
        }
        else
        {
             throw new Expcetion("InvalidType");
        }
    }
