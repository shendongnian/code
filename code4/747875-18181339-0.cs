     private DateTime _datetime;
        public DateTime DateTime
        {
            get
            {
                return _datetime;
            }
            set
            {
                _datetime = value;
                OnPropertyChanged("DateTime");
            }
        }
