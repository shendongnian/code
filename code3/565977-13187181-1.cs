    class ViewSchedule : IFromToDateProvider
    {
        DateTime _from;
        public DateTime From
        {
            get { return _from; }
            set
            {
                if (_from == value) return;
                _from = value;
                OnPropertyChanged("From");
            }
        }
        DateTime _to;
        public DateTime To
        {
            get { return _to; }
            set
            {
                if (_to == value) return;
                _to = value;
                OnPropertyChanged("To");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
