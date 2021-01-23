    RelayCommand _voltageCommand ;
    public ICommand VoltageCommand 
    {
        get
        {
            if (_voltageCommand == null)
            {
                _voltageCommand = new RelayCommand(param => this.DoSomethingExecute,
                    param => this.DoSomethingCanExecute);
            }
            return _voltageCommand;
        }
    }
