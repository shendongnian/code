    public class Mole: PropertyChangedBase
    {
        private bool _isUp;
        public bool IsUp
        {
            get { return _isUp; }
            set
            {
                _isUp = value;
                OnPropertyChanged("IsUp");
            }
        }
    }
