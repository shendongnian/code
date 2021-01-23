    public UserControl UserControl
    {
         get { return _userControl; }
         set
         {
             if (_userControl != value) 
             {
                _userControl = value;              // first
                 OnPropertyChanged("UserControl"); // second
             }
         } 
    }
