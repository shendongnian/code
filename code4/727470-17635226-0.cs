      public class Video : INotifyPropertyChanged
        {
            public Video(Action summationCallback)
            {
                _summationCallback = summationCallback;
            }
            private readonly Action _summationCallback;
            private double _duration;
            public double Duration
            {
                get { return _duration; }
                set
                {
                    if (value != _duration)
                    {
                        _duration = value;
                        OnPropertyChanged("Duration");
                        if (_summationCallback != null)
                        {
                            _summationCallback();
                        }
                    }
                }
            }
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string name)
            {
                var handler = System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null);
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
            #endregion
        }
