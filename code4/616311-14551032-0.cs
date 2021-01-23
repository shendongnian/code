    private int  _Score;
    [Column]
    public int  Score
    {
        get
        {
            return _Score;
        }
        set
        {
            if (_Score != value)
            {
                NotifyPropertyChanging("Score");
                _Score = value;
                NotifyPropertyChanged("Score");
            }
        }
    }
