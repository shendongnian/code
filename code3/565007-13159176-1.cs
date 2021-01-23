    public async Task<int> AccessTheWebAndDoubleAsync()
    {
        var task = AccessTheWebAsync();
        int result = await task;
        return result * 2;
    }
