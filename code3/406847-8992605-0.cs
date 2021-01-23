    protected DelegateCommand _CheckAllZonesCommand = new DelegateCommand()
    {
        ExecuteMethod = new Action<object>(delegate(object o) { ((ZonesView)o).CheckAllZones(); }),
        CanExecuteMethod = new Func<bool>(delegate() { return true; })
    };
    public ICommand CheckAllZonesCommand { get { return _CheckAllZonesCommand; } }
    protected DelegateCommand _UncheckAllZonesCommand = new DelegateCommand()
    {
        ExecuteMethod = new Action<object>(delegate(object o) { ((ZonesView)o).UncheckAllZones(); }),
        CanExecuteMethod = new Func<bool>(delegate() { return true; })
    };
    public ICommand UncheckAllZonesCommand { get { return _UncheckAllZonesCommand; } }
