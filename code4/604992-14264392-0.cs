    public class PleaseChangeTheNameOfThisClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        private TimeSpan _raiseTime;
        public TimeSpan RaiseTime
        { 
            get { return _raiseTime; }
            set 
            {
                if (_raiseTime != value)
                {
                    _fallTime = value;
                    RaisePropertyChanged("RaiseTime");
                    RaisePropertyChanged("TotalTime");
                }
            }
        }
        private TimeSpan _fallTime;
        public TimeSpan FallTime  
        { 
            get { return _fallTime; }
            set 
            {
                if (_fallTime != value)
                {
                    _fallTime = value;
                    RaisePropertyChanged("FallTime");
                    RaisePropertyChanged("TotalTime");
                }
            }
        }
        public TimeSpan TotalTime
        { 
            get { return RaiseTime + FallTime; }
        }
    }
