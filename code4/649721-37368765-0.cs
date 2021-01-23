     // defines the binding property to the flipview
     private ObservableCollection<BitmapImage> _pictureGallery;
            public ObservableCollection<BitmapImage> PictureGallery
            {
                get { return _pictureGallery; }
                set
                {
                    if (_pictureGallery != value)
                    {
                        _pictureGallery = value;
                        onPropertyChanged("PictureGallery");
                    }    
    
                }
            }
  
    // This defines the property change event
    public event PropertyChangedEventHandler PropertyChanged;
            private void onPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
