    public void GetEmployees(int xyz, EventHandler<GetListCompletedEventArgs> eventHandler)
    {
        _client.GetListCompleted += (sender, args) =>
        {
            eventHandler(sender, e); 
            _client.GetListCompleted -= eventHandler;
        };
        _client.GetListAsync(xyz);
    }
