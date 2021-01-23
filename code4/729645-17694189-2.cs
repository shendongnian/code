        public bool IsSaveCanvas
        {
            get { return _isSaveCanvas; }
            set
            {
                _isSaveCanvas = value;
                RaisePropertyChanged("IsSaveCanvas");
            }
        }
