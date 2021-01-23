    public class MyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Video> MyCollection { get; set; }
        public MyViewModel()
        {
            MyCollection = new ObservableCollection<Video>();
            Video v = new Video(SummationCallback);
            MyCollection.Add(v);
        }
        private void SummationCallback()
        {
            SumOfAllDurations = MyCollection.Sum(q=>q.Duration)
        }
        private double _sumOfAllDurations;
        public double SumOfAllDurations
        {
            get { return _sumOfAllDurations; }
            set
            {
                if (value != _sumOfAllDurations)
                {
                    _sumOfAllDurations = value;
                    OnPropertyChanged("SumOfAllDurations");
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
