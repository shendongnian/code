    private object _cachedObject = null;
    public object CachedObject 
    {
        get 
        {
            if (_cachedObject == null)
            {
                log(MethodBase.GetCurrentMethod().Name, "creating cached object");
                _cachedObject = createCachedObject();
            }
            return _cachedObject;
        }
    }
