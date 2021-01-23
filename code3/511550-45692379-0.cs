     private BitmapImage _ImageSource;
     public BitmapImage ImageSource
     {
         get { return this._ImageSource; }
         set { this._ImageSource = value; this.OnPropertyChanged("ImageSource"); }
     }
     private void OnPropertyChanged(string v)
     {
         // throw new NotImplementedException();
         if (PropertyChanged != null)
             PropertyChanged(this, new PropertyChangedEventArgs(v));
     }
     public event PropertyChangedEventHandler PropertyChanged;
