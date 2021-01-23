        public bool Busy
        {
            get{return _Busy;}
            set
            {
               if(value != _Busy)
                 _Busy = value;
               OnPropertyChanged("Busy");
            }
        }
