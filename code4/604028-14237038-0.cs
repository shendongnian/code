    public MyModel CurrentModel
    {
        get { return _model; }
        set 
        {
            if (_model != value)
            {
                _model = value;
                RaisePropertyChanged("CurrentModel");
            }
        }
    }
