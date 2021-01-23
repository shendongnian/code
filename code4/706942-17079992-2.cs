    public class MainViewModel // Should implement INotifyPropertyChange
    {
        public MainViewModel()
        {
            LapTimes = new ObservableCollection<TimeSpan>();
        }
        public ObservableCollection<TimeSpan> LapTimes { get; private set; }
        
        private void CalculateStuff()
        {
            // calculate times
        }
    }
