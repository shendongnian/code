    public Whatever StapelStatus
    {
        get { return _stapelStatus; }
        set
        {
            _stapelStatus = value;
            OnPropertyChanged("StapelStatus");
            StatusColor = value == StapelStatus.Neu ? new SolidColorBrush(Colors.CornflowerBlue) : new SolidColorBrush(Colors.DarkOrange);
        }
    }
    public Brush StatusColor
    {
        get { return _statusColor; }
        set
        {
            _statusColor = value;
            OnPropertyChanged("StatusColor");
        }
    }
