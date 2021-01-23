    public List<int> Progress
    {
        get
        {
            return _progress;
        }
        set
        {
            if (value != _progress)
            {
                Progress = value;
                NotifyPropertyChanged("Progress");
            }
        }
    }
