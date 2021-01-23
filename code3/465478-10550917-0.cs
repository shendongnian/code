    _model.PropertyChanged += PropertyChangedEventHandler(OnPropertyChangedModel);
    void OnPropertyChangedModel(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        OnPropertyChanged(e.PropertyName);
    }
