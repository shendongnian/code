    public class AverageSampleViewModel: PropertyChangedBase
    {
        public int Value { get; set; }
        private bool _isBelowAverage;
        public bool IsBelowAverage
        {
            get { return _isBelowAverage; }
            set
            {
                _isBelowAverage = value;
                OnPropertyChanged("IsBelowAverage");
            }
        }
    }
