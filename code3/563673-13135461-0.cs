    public EEPROMViewModel ParentVM
            {
                get { return _parentVm; }
                set
                {
                    _parentVm = value;
                    OnPropertyChanged("ParentVM");
                }
            }
