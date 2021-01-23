    private bool _isVisibleDelete;
    public bool IsVisibleDelete
    {
        get { return _isVisibleDelete; }
        set { _isVisibleDelete = value; RaisePropertyChanged(() => IsVisibleDelete); }
    }
    
    public ICommand ShowMoreOptions { get; private set; }
    private void OnShowMoreOptions()
    {
        IsVisibleDelete = !IsVisibleDelete;
    }
