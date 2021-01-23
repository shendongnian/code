    public bool busy
    {
        get
        {
             return _isUserLoading || _isOtherDataLoading;
        }
    }
    public bool IsUserLoading
    {
        get
        {
             return _isUserLoading;
        }
        set
        {
           bool busy = Busy;
           _isUserLoading = value;
           if (busy != Busy) RaisePropertyChanged("Busy");
        }
    }
