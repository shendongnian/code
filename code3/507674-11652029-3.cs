    private readonly Action _action;
    public SimpleDelegateCommand(Action action)
    {
        _action = action;
    }
    public bool CanExecute(object parameter)
    {
        return true;
    }
    public event EventHandler CanExecuteChanged;
    public void Execute(object parameter)
    {
        if(_action != null)
        {
            _action();
        }
    }
