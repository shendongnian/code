    public sealed class ViewModel : INotifyPropertyChanged
    {
        private TimeSpan _raiseTime;
        private TimeSpan _fallTime;
        public TimeSpan RaiseTime
        {
            get { return _raiseTime; }
            private set
            {
                if (SetProperty(ref _raiseTime, value))
                {
                    OnPropertyChanged("TotalTime");
                }
            }
        }
        public TimeSpan FallTime
        {
            get { return _fallTime; }
            private set
            {
                if (SetProperty(ref _fallTime, value))
                {
                    OnPropertyChanged("TotalTime");
                }
            }
        }
        public TimeSpan TotalTime
        {
            get { return RaiseTime + FallTime; }
        }
        #region Put these in a base class...
        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
