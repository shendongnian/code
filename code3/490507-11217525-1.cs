    class MyViewModel : INotifyPropertyChanged
    {
        private Visibility _logoVisibility = Visibility.Visible;
        private Visibility _notifVisibility = Visibility.Collapsed;
        public Visibility LogoVisibility
        {
            get { return _logoVisibility; }
        }
        public Visibility NotificationVisibility
        {
            get { return _notifVisibility; }
        }
        public bool NotificationIconEnabled
        {
            get { return _notifVisibility == Visibility.Visible; }
            set
            {
                if (value)
                {
                    _logoVisibility = Visibility.Collapsed;
                    _notifVisibility = Visibility.Visible;
                }
                else
                {
                    _logoVisibility = Visibility.Visible;
                    _notifVisibility = Visibility.Collapsed;
                }
                OnPropertyChanged("LogoVisibility");
                OnPropertyChanged("NotificationVisibility");
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion // INotifyPropertyChanged Members
    }
