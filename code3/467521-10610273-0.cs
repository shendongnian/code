    public class PlatypusInfo : INotifyPropertyChanged
    {         
        public event PropertyChangedEventHandler PropertyChanged;
        private String _PlatypusName;
        public String PlatypusName 
        { 
           get
           {
              return _PlatypusName;
           }
           set 
           {
              _PlatypusName = value;
              NotifyPropertyChanged("PlatypusName");
           }
        }
        private void NotifyPropertyChanged(String info)
        {
           PropertyChangedEventHandler property_changed = PropertyChanged;
           if (property_changed != null)
           {
              property_changed(this, new PropertyChangedEventArgs(info));
           }
        }
    }
