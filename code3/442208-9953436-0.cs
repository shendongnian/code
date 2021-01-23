    private bool _picked;
    public bool Picked
    {
        get { return _picked; }
        set
        {
            if (_picked != value)
            {
                _picked = value;
                if (null != PropertyChanged)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Picked"));
                }
            }
        }
    }
