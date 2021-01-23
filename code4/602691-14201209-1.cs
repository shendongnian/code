        public bool DncCanExecute
        {
            get
            {
               return "" != _dncNotes;
            }
        }
        public string DNCNotes
        {
            get { return _dncNotes; }
            set { 
                if (_dncNotes == value) return;
                if (("" == _dncNotes && "" != value) || ("" != _dncNotes && "" == value))
                {
                    _dncNotes = value;
                    OnPropertyChanged("DncCanExecute");
                }
                else
                {
                    _dncNotes = value;
                }
                OnPropertyChanged("DNCNotes");
            }
        }
