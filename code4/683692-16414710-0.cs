        private Datetime mActualDate;
        public DateTime ActualDate
        {
            get
            {
                return mActualDate;
            }
            set
            {
                if (value != null)
                {
                   
                            mActualDate= value;
                            NotifyPropertyChanged("ActualDate");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        // NotifyPropertyChanged will raise the PropertyChanged event, 
        // passing the source property that is being updated.
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
