    public event PropertyChangedEventHandler PropertyChanged = delegate { };
        void NotifyPropertyChanged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
