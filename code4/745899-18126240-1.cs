    public void Ping()
    {
        _pingClient.Channel.Ping();
        Pinger.CanPing = false;
        PingCommand.CanExecute1 = false;
        OnPropertyChanged("CanPing");
    }
