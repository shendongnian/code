    class SimpleViewModel: INotifyPropertyChanged
    {
        private bool _checked;
        // The property to bind to
        public bool Checked
        {
            get { return _checked; }
            set { _checked = value; OnPropertyChanged("Checked");  }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));  
        }
    }
