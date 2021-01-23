    class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool _captionVisible;
        public bool CaptionVisible
        {
            get { return _captionVisible; }
            set
            {
                if(_captionVisible != value)
                {
                    _captionVisible = value;
                    RaisePropertyChanged("CaptionVisible");
                }
            }
        }
    }
