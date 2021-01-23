    class Blah : INotifyPropertyChanged
    {
        // Used for triggering the event
        public event PropertyChangedEventHandler PropertyChanged;
        
        // Called when the property changes
        protected void OnPropertyChanged(String propertyName)
        {
            // Retrieve handler
            PropertyChangedEventHandler handler = this.PropertyChanged;
            // Check to make sure handler is not null
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        private bool _blahIsChecked;
        public bool BlahIsChecked
        {
            get {
                return _blahIsChecked;
            }
            set {
                _blahIsChecked = value;
                OnPropertyChanged("BlahIsChecked);
            }
        }
    }
