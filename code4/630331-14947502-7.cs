    public class MyListBoxItemModel : INotifyPropertyChanged
    {
        private string _title;
        private string _line2 = "Line2";
        private BitmapImage _image;
        public string Title
        {
            get { return _title; }
            set { _title = value; NotifyPropertyChanged("Title"); }
        }
        public string Line2
        {
            get { return _line2; }
            set { _line2 = value; NotifyPropertyChanged("Line2"); }
        }
        
        public BitmapImage Image
        {
            get { return _image; }
            set { _image = value; NotifyPropertyChanged("Image"); }
        }
     
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }
    }
