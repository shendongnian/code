    public ObservableCollection<Part> Parts
    {
        get { return parts; }
        set { parts = value; NotifyPropertyChanged("Parts");
    }
    
