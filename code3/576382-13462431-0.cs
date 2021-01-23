    public ViewModel1(IEventAggregator eventAggregator)
    {
        _eventAggregator=eventAggregator;
    }
    private void SendMessage()
    {
        _eventAggregator.GetEvent<UserLogin>().Publish(new UserLogin(_userName,_password);
    }
