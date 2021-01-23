    class ViewModel
    {
        private async void _StartCountdown()
        {
            Running = true;
            // NOTE: UTC times used internally to ensure proper operation
            // across Daylight Saving Time changes. An IValueConverter can
            // be used to present the user a local time.
            // NOTE: RemainingTime is the raw data. It may be desirable to
            // use an IValueConverter to always round up to the nearest integer
            // value for whatever is the least-significant component displayed
            // (e.g. minutes, seconds, milliseconds), so that the displayed
            // value doesn't reach the zero value until the timer has completed.
            DateTime startTime = DateTime.UtcNow, endTime = startTime + Duration;
            TimeSpan remainingTime, interval = TimeSpan.FromMilliseconds(100);
            StartTime = startTime;
            remainingTime = endTime - startTime;
            while (remainingTime > TimeSpan.Zero)
            {
                RemainingTime = remainingTime;
                if (RemainingTime < interval)
                {
                    interval = RemainingTime;
                }
                // NOTE: arbitrary update rate of 100 ms (initialized above). This
                // should be a value at least somewhat less than the minimum precision
                // displayed (e.g. here it's 1/10th the displayed precision of one
                // second), to avoid potentially distracting/annoying "stutters" in
                // the countdown.
                await Task.Delay(interval);
                remainingTime = endTime - DateTime.UtcNow;
            }
            RemainingTime = TimeSpan.Zero;
            StartTime = null;
            Running = false;
        }
        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get { return _duration; }
            set { _UpdateField(ref _duration, value); }
        }
        private DateTime? _startTime;
        public DateTime? StartTime
        {
            get { return _startTime; }
            private set { _UpdateField(ref _startTime, value); }
        }
        private TimeSpan _remainingTime;
        public TimeSpan RemainingTime
        {
            get { return _remainingTime; }
            private set { _UpdateField(ref _remainingTime, value); }
        }
        private bool _running;
        public bool Running
        {
            get { return _running; }
            private set { _UpdateField(ref _running, value, _OnRunningChanged); }
        }
        private void _OnRunningChanged(bool obj)
        {
            _startCountdownCommand.RaiseCanExecuteChanged();
        }
        private readonly DelegateCommand _startCountdownCommand;
        public ICommand StartCountdownCommand { get { return _startCountdownCommand; } }
        public ViewModel()
        {
            _startCountdownCommand = new DelegateCommand(_StartCountdown, () => !Running);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void _UpdateField<T>(ref T field, T newValue,
            Action<T> onChangedCallback = null,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return;
            }
            T oldValue = field;
            field = newValue;
            onChangedCallback?.Invoke(oldValue);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
