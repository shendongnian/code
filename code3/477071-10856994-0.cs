    public class ThumbnailItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private string _thumbnailPath;
        public string ThumbnailPath 
        {
            get { return _thumbnailPath; }
            set
            {
                if (value == null || _thumbnailPath != value)
                {
                    _thumbnailPath = value;
    
                    NotifyPropertyChanged("ThumbnailPath");
                }
            }
        }
        protected void NotifyPropertyChanged(string propertyName) 
        { 
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
        }
    }
