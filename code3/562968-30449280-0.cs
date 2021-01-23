    private RelayCommand _addPhoneCommand;
    public RelayCommand AddPhoneCommand
    {
        get
        {
            if (_addPhoneCommand == null)
            {
                _addPhoneCommand = new RelayCommand(
                    (parameter) => AddPhone(parameter),
                    (parameter) => IsValidPhone(parameter)
                );
            }
            return _addPhoneCommand;
        }
    }
    public void AddPhone(object parameter)
    {
        var text = (string)parameter;
        ...
    }
    public void IsValidPhone(object parameter)
        var text = (string)parameter;
        ...
    }
    
