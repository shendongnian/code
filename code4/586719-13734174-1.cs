    public class SessionData : INotifyPropertyChanged
    {
        private static bool _rememberUser;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool RememberUser
        {
            get { return _rememberUser; }
            set
            {
                _rememberUser = value;
                OnPropertyChanged();
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
