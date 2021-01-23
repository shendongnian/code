    int taskResult = AccessTheWebAndDouble().Result;
    public async Task<int> AccessTheWebAndDouble()
    {
        int task = AccessTheWeb();
        return task;
    }
