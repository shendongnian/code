    public bool AppBarIsOpen
    {
        get { return this._appBarIsOpen; }
    
        set
        {
            if (this._appBarIsOpen == value) { return; }
    
            this._appBarIsOpen = value;
            this.RaisePropertyChanged("AppBarIsOpen"); // without INotifyPropertyChanged it doesn't work
        }
    }
    
    
    <AppBar
        IsSticky="True"
        IsOpen="{Binding Path=AppBarIsOpen, Mode=TwoWay}">
