    public class ThumbnailImage : INotifyPropertyChanged
    {
        private string _path;
        public string Path
        {
            get { return _path; }
            set
            {
                if (value != _path)
                {
                    _path = value;
                    if (PropertyChanged != null)
                    {
                        var args = new PropertyChangedEventArgs("Path");
                        PropertyChanged(this, args);
                    }
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
