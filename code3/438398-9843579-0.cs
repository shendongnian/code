    IDictionary<string, IEnumerable<T>> Cache;
    IEnumerable<T> GetData<T>(string query)
    {
        var key = typeof(T).Name + query;
        if (!this.Cache.ContainsKey(key))
        {
            // get from database
            var data = SomeRepository.GetData(query);
            this.Cache[key] = value;
        }
        return this.Cache[key]
    }
