    RelayCommand _btnCommand;
    public ICommand Button1Command
    {
        get
        {
            if (_btnCommand == null)
            {
                _btnCommand = new RelayCommand(param => this.ExecuteButton1(),
                    param => this.CanButton1());
            }
            return _btnCommand;
        }
    }
    
    public void ExecuteButton1()
    {
    }
    
    public bool CanButton1()
    {
        return true;
    }
