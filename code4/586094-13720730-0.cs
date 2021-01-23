    public event PropertyChangedEventHandler PropertyChanged;
    private bool _countLabelVisible = false;
    private void RaisePropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
    public bool CountLabelVisible 
    { 
        get
        {
            return _countLabelVisible;
        }
        set
        {
            _countLabelVisible = value;
            RaisePropertyChanged("CountLabelVisible");
        }
    }
