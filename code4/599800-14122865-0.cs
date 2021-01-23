    Class A:INotifyPropertyChanged
    {
        #region EventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        public Style SetTextBlockFont
        {
            set
            {
                timeHour.Style = value;
                RaisePropertyChanged("SetTextBlockFont");
            }
        }
    }
