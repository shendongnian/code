    public void GetEmployees(int xyz, EventHandler<GetListCompletedEventArgs> eventHandler)
    {
        _client.GetListCompleted = eventHandler;
        _client.GetListAsync(xyz);
    }
