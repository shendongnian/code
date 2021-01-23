        private bool _isVisible=true;
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible= value;
                NotifyPropertyChanged("IsVisible");
            }
        }
