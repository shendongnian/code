    public class SessionData : INotifyPropertyChanged
    {
        private static bool _rememberUser;
    
        public bool RememberUser
        {
            get { return _rememberUser; }
            set
            {
                _rememberUser = value;
                OnPropertyChanged("RememberUser");
            }
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
