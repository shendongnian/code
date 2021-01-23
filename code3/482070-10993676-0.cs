    public object CurrentView
    {
        get { return _currentView; }
        set {
            _currentView = value; this.RaiseNotifyPropertyChanged("CurrentView");}
    }
