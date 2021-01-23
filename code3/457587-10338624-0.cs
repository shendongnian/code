    private IEnumerable<Genre> _genres; // backing field
    public IEnumerable<Genre> 
    { 
        get { return _genres; }
        set
        {
            _genres = value;
            OnPropertyChanged("Genres");
        }
    }
