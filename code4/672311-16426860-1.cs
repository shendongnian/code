    public IEnumerable<MYPOCO> GetData(string someParameter, int anotherParameter)
    {
        Criteria criteria = new Criteria();
        criteria.Set("someParameter", someParameter)
                .Set("anotherParameter", anotherParameter);
        // we can check the cache now based on this...
    }
