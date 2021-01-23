    private ICommand _quitCommand;
    //Menu item
    public ICommand QuitCommand 
    {
        get { return _quitCommand; }
        private set
        {
            if (value == _quitCommand) return;
    
            _quitCommand = value;
            base.RaisePropertyChanged("QuitCommand");        
        }
    }
    
    public MyViewModel()
    {
        QuitCommand = new RelayCommand(() => Quit());
    }
