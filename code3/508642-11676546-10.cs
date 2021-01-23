        int needleValue = 1;
        public int NeedleValue 
        {
            get
            {
                return needleValue;
            }
            set
            {
                needleValue = value;
                NotifyPropertyChanged("NeedleValue");
            }
        }
