    public class StopwatchWrapper : INotifyPropertyChanged
    {
        Stopwatch _stopwatch;
        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    OnPropertyChanged("IsRunning");
                }
            }
        }
        public StopwatchWrapper()
        {
            _stopwatch = new Stopwatch();
            _isRunning = false;
        }
        public void Start()
        {
            _stopwatch.Start();
            IsRunning = _stopwatch.IsRunning;
        }
        public void Stop() 
        {
            _stopwatch.Stop();
            IsRunning = _stopwatch.IsRunning;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
