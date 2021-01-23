    /// <summary>
    /// Gets the OnValidateExecute.
    /// </summary>
    public RelayCommand OnValidateExecute
    {
        get
        {
            return _onValidateExecute 
                ?? (_onValidateExecute = new RelayCommand(
                                        () => IsValid()));
        }
    }
    private RelayCommand _onValidateExecute;
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
    
    public myViewModel()
    {
    }
    
    public bool IsValid()
    {
        // other codes
        IsOk = MethodName();
    }
