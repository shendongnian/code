    private bool _isVisibleDelete;
    public bool IsVisibleDelete
    {
        get { return _isVisibleDelete; }
        set { _isVisibleDelete = value; SendPropertyChanged("IsVisibleDelete"); }
    }
    public ICommand ShowMoreOptions { get; private set; }
    private void OnShowMoreOptions()
    {
        if (System.Windows.Forms.Control.ModifierKeys == System.Windows.Forms.Keys.Shift)
            IsVisibleDelete = true;
    }
    public ICommand HideMoreOptions { get; private set; }
    private void OnHideMoreOptions()
    {
        IsVisibleDelete = false;
    }
