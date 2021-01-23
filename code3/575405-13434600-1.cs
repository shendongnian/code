        public string FieldInObject
        {
            get
            {
                return _FieldInObject;
            }
            set
            {
                if (value != _FieldInObject)
                {
                    _FieldInObject = value;
                    //do not add this code here
                    //NotifyPropertyChanged("CurrentPlayer");
                }
            }
        }
