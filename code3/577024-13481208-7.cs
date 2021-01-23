        public int iYCoordinate
        {
            get { return _iYCoordinate; }
            set
            {
                _iYCoordinate = value;
                OnPropertyChanged(() => iYCoordinate);
            }
        }
