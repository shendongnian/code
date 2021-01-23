    public bool IsOk
    {
        get
        {
            return _isOk;
        }
        set
        {
            if (_isOk != value)
            {
                _isOk = value;
                RaisePropertyChanged("IsOk");
                RaisePropertyChanged("ButtonImage");
            }
        }
    }
    
    public Image ButtonImage
    {
        get
        {
            if (_isOk)
                return _okImage;
            else
                return _cancelImage;
        }
    }
