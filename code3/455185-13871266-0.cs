    private void NotifyPropertyChanged(String info)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
