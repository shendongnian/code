        public bool CanActivated
        {
            get
            {
                return _canActivated;
            }
            set
            {
                _canActivated = value;
                OnNotifyPropertyChanged("CanActivated");
            }        
        }
