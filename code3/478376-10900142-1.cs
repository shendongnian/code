    public class ViewModel : INotifyPropertyChanged
    {
        public IList<Country> Countries
        {
            get { return _countries; }
            private set
            {
                _countries = value;
                OnPropertyChanged("Countries");
            }
        }
     
        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            private set
            {
                _selectedCountry= value;
                OnPropertyChanged("SelectedCountry");
            }
        }
    
    }
