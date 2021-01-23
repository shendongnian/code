     public string DeviceName
     {
         get { return _name; }
         set
         {
             _name = value;
             NotifyPropertyChanged("DeviceName");
             NotifyPropertyChanged("Combined");
         }
     }
     public string Description
     {
         get { return _description; }
         set
         {
             _description = value;
             NotifyPropertyChanged("Description");
             NotifyPropertyChanged("Combined");
         }
     } 
     public string Combined
     {
         get { return string.Format("{0} : {1}", _description, _deviceName; }
     }
