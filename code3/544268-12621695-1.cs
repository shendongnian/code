     private ComDeviceInfo _model;
     public string DeviceName
     {
         get { return _model.Name; }
         set
         {
             _model.Name = value;
             NotifyPropertyChanged("DeviceName");
             NotifyPropertyChanged("Combined");
         }
     }
     public string Description
     {
         get { return _model.Description; }
         set
         {
             _model.Description = value;
             NotifyPropertyChanged("Description");
             NotifyPropertyChanged("Combined");
         }
     } 
     public string Combined
     {
         get { return string.Format("{0} : {1}", _description, _deviceName; }
     }
