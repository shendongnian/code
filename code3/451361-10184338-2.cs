     private RelayCommand _keyPressCommand;
        public RelayCommand KeyPressCommand
        {
            get
            {
                if (_keyPressCommand== null)
                {
                    _keyPressCommand = new RelayCommand(
                     KeyPressExecute,
                     CanKeyPress);
                }
                return _keyPressCommand;
            }
        }
    private void KeyPressExecute(object p)
    {
        // HANDLE YOUR KEYPRESS HERE
    }
    
    private bool CanSaveZone(object parameter)
    {
       return true;
    }
