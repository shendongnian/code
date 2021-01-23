    public class Avatar : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private Visibility _imgVis;
        public Visibility ImgVis 
        { 
           get{ return _imgVis; }
           set
           { 
              if (value == _imgVis) return;
              _imgVis = value;
              NotifyPropertyChanged("ImgVis");
           }
        }
    }
