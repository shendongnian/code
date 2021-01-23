    public async Task<bool> TryBlah(string key, Action<int> value)
    {
        int something = await DoLongRunningIO();
        value(something)
        return true;         
    }
