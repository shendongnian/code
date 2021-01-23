    public event EventHandler CanExecuteChanged
    {
        add
        {
            ...
            CommandManager.RequerySuggested += value;
        }
        ... 
    }
