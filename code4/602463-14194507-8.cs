        public double _minHeightRowOne;
        public double MinHeightRowOne
        {
            get
            {
                return _minHeightRowOne;
            }
            set
            {
                _minHeightRowOne = value;
                OnPropertyChanged("MinHeightRowOne");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
