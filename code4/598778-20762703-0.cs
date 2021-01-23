    private void NotifyPropertyChanged(String propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (null != handler)
        {
            Dispatcher dsp = Deployment.Current.Dispatcher;
            dsp.BeginInvoke(() => { 
                handler(this, new PropertyChangedEventArgs(propertyName));
            });
        }
    }
