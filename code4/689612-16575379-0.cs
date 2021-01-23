    public ICommand CloseWindowCommand
    {
        get
        {
            return new RelayCommand<Window>(SystemCommands.CloseWindow);
        }
    }
