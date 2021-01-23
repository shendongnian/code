    private MvxRelayCommand _disconnectCommand;
    public IMvxCommand DisconnectCommand
    {
        get
        {
            if (_disconnectCommand == null)
                _disconnectCommand = new MvxRelayCommand(this.GetService<IConnectionService>().Disconnect, item => this.IsItemConnected(item));
            return _disconnectCommand;
        }
    }
    
    private void SomeServiceNotificationHandler()
    {
        _disconnectCommand.RaisePropertyChanged();
    }
    
    private bool IsItemConnected(object thing)
    {
        return /* your code */;
    }
