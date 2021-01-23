    /// <summary>
    /// Gets the OnSaveExecute.
    /// </summary>
    public RelayCommand OnSaveExecute
    {
        get
        {
            return _onSaveExecute 
                ?? (_onSaveExecute = new RelayCommand(
                                        () =>
                                        {
                                                  // Save action or call save method
                                        },
                                        () => IsOk));
        }
    }
    private RelayCommand _onSaveExecute;
    
    /// <summary>
    /// Sets and gets the IsOk property.
    /// Changes to that property's value raise the PropertyChanged event.
    /// </summary>
    public bool IsOk
    {
        get { return _isOk; }
        set
        {
            if (_isOk == value)
            {
                return;
            }
            _isOk = value;
            RaisePropertyChanged("IsOk");
            OnSaveExecute.RaiseCanExecuteChanged();
        }
    }
    private bool _isOk = false;
    /// <summary>
    /// Sets and gets the BoundProerty property.
    /// Changes to that property's value raise the PropertyChanged event.
    /// </summary>
    public string BoundProerty
    {
        get { return _boundProerty; }
        set
        {
            if (_boundProerty == value)
            {
                return;
            }
            _boundProerty = value;
            RaisePropertyChanged("BoundProerty");
            IsValid();
        }
    }
    private string _boundProerty = false;
    
    public myViewModel()
    {
    }
    
    public bool IsValid()
    {
        // other codes
        IsOk = MethodName();
    }
