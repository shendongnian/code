        private bool _close;
        public bool Close
        {
            get { return _close; }
            set
            {
                if (_close == value)
                    return;
                _close = value;
                NotifyPropertyChanged("Close");
            }
        }
