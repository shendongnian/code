    static IEnumerable<int> CachedData
    {
        get
        {
            if (_cachedData == null)
            {
                _cachedData = LoadDataFromDatabase().ToList();
            }
            return _cachedData;
        }
    }
