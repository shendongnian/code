      public bool Checked {
            get
            {
                return checkedValue;
            }
            set
            {
                this.checkedValue = value;
                NotifyPropertyChanged("Checked");
            }
        }
