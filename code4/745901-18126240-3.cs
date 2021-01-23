    public void Ping()
    {
        _pingClient.Channel.Ping();
        Pinger.CanPing = false;
        PingCommand.CanExecute1 = false;
        OnPropertyChanged("CanPing");
    }
    protected virtual void OnPong(PongEventArgs e)
    {
        Pinger.CanPing = true;
        PingCommand.CanExecute1 = true;
        OnPropertyChanged("CanPing");
    }
