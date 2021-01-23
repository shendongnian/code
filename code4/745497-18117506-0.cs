    public async Task<Tuple<bool, TResult>> TryBlah<TResult>(string key)
    {
        var resultType = typeof(TResult);
        // ... perform some slow io, return new Tuple<bool, TResult>(...)
    }
