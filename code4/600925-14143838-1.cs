        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }
            set
            { 
                this.isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }
