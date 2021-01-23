    class CodeClass : INotifyPropertyChanged
    {
    
        private string _myProperty;
        public string MyProperty
        {
            get { return _myProperty; }
            set
            {
                _myProperty = value;
                OnPropertyChanged("MyProperty");
            }
        }
    
        #region INotifyPropertyChanged implementation
    
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
        
        #endregion
        
    }
