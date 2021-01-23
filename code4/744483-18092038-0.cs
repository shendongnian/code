    public string Phone
    {
        get { return _phone; }
        set
        {
             string setterCallerName = new StackFrame(1).GetMethod().Name;
            _phone = value;
            OnPropertyChanged();
        }
    }
