    public IList<Example> GetList(string _state)
    {
    
        IList<Example> cities = new List<Example>();
        Cache cache = HttpContext.Current.Cache;
        if (cache[_state] != null)
            cities = (IList<Example>)cache[_state];
        else
        {
            //Do your calls
            cache.Insert(_state, cities);
        }
        return cities;
    }
