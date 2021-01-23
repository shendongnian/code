    public ICommand ClearCommand { get; private set; }
    // ...
    public VoltageViewModel(...)
    {
        // ...
        this.ClearCommand = new DelegateCommand(
            () => this.VoltageChannelList.Clear(),
            () => this.VoltageChannelList.Count > 0);
    }
