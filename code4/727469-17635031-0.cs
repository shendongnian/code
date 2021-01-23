    private void Subscribe()
    {
        foreach(var video in _videos)
        {
            video.NotifyPropertyChanged += OnVideoPropertyChanged;
        }
    }
    private void OnVideoPropertyChanged(object sender, NotifyPropertyChangedEventArgs e)
    {
        if(e.PropertyName == "Duration")
        {
            this.RecalculateSum();
            this.RaisePropertyChanged("Sum");  //Or call this from inside RecalculateSum()
        }
    }
