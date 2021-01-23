    public class VideoFile : INotifyPropertyChanged
    {
        private string _filePath;
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            protected set
            {
                _filePath = value;
                OnPropertyChanged("FilePath");
                OnPropertyChanged("Extension");
                OnPropertyChanged("FileName");
            }
        }
        public uint ID { get; protected set; }
        public string Extension { get { return Path.GetExtension(FilePath); } }
        public string FileName { get { return Path.GetFileName(FilePath); } }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
