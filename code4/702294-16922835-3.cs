    public class UserControlViewModel:PropertyChangedBase
    {
        private double _y;
        public double Y
        {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged("Y");
            }
        }
        public Command PressMeCommand { get; set; }
    }
