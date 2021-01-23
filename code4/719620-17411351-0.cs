    public ICommand OkCmd
    {
        get { return _okCmd ?? (_okCmd = new DelegateCommand(Ok)); }
    }
    private DelegateCommand _okCmd;
