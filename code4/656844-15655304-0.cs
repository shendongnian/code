    private bool _isDirty;
    public bool IsDirty
    {
        get { return _isDirty; }
        protected set
        {
            _isDirty = value;
            OnPropertyChanged("IsDirty");
        }
    }
