    class ImageHandler : INotifyPropertyChanged
    {
        private BitmapImage imageToDisplay;
        public BitmapImage ImageToDisplay
        {
            get { return imageToDisplay; }
            set
            {
                if (imageToDisplay != value)
                {
                    imageToDisplay = value;
                    OnPropertyChanged("ImageToDisplay");
                }
            }
        }
        public ImageHandler() { }
        // .... Other codes
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
