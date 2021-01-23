    RelayCommand _voltageCommand ;
    public ICommand VoltageCommand 
    {
        get
        {
            if (_voltageCommand == null)
            {
                _voltageCommand = new RelayCommand(this.DoSomethingExecute,
                    this.DoSomethingCanExecute);
            }
            return _voltageCommand;
        }
    }
