    private RelayCommand _showElement;
    public RelayCommand ShowElement
    {
        get
        {
            return _showElement?? (_showElement= new RelayCommand(() =>
                                 {
                                     this.ElementVisibility = Visibility.Visible;
                                 ));
        }
    }
