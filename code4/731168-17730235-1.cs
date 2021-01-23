    private ObservableCollection<Worker> _Workers;
    public ObservableCollection<Worker> Workers
    {
        get { return _Workers; }
        set
        {
            if (value != _Workers)
            {
                _Workers = value;
                NotifyPropertyChanged("Workers")
            }
        }
    }
