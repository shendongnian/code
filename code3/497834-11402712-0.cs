    public class SuperProspect : INotifyPropertyChanged
    {
        private readonly Prospect _prospect;
        public SuperProspect(Prospect prospect)
        {
            _prospect = prospect;
        }
        public State DriverLicenseState
        {
            get
            {
                return _prospect.DriverLicenseState;
            }
            set
            {
                _prospect.DriverLicenseState = value;
                OnPropertyChanged("DriverLicenseState");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
