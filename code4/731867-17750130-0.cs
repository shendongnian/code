    ObservableCollection<Section> _col;
    public ObservableCollection<Section> Sections
    {
        get { return _col; }
        set
        {
            _col = value;
            OnPropertyChanged("Sections");
        }
    }
