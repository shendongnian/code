    private bool isBusy = false; 
     
    public bool IsBusy 
     
    { 
     
        get { return isBusy; } 
     
        internal set { isBusy = value; OnPropertyChanged("IsBusy"); } 
     
