      public bool Checked {
            get
            {
                return checkedValue;
            }
            set
            {
                NotifyPropertyChanged("Checked");
                this.checkedValue = value;
            }
        }
