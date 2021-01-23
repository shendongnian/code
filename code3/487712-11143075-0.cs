    RelayCommand _saveCommand;
    public ICommand SaveCommand
    {
        get
        {
            if (_saveCommand == null)
            {
                _saveCommand = new RelayCommand(param => this.Save(),
                    param => this.CanSave );
            }
            return _saveCommand;
        }
    }
