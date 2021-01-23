    public int ActiveTabItemIndex
    {
        get{ return _ActiveTabItemIndex; }
        set
        {
            if(_ActiveTabItemIndex != value)
            {
                _ActiveTabItemIndex = value;
                RaisePropertyChanged("ActiveTabItemIndex");
            }
        }
    }
