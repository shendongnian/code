    private BitmapImage _bImage;
    public BitmapImage BImage
    {
       get { return _bImage; }
       set
       {
          _bImage= value;
          NotifyPropertyChanged("BImage");
       }
    }
