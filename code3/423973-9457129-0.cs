        private ObservableCollection<KeyValuePair<string, string>> _yearValues = new   ObservableCollection<KeyValuePair<string, string>>();
        public ObservableCollection<KeyValuePair<string, string>> YearValues
        {
            get
            {
                return _yearValues;
            }
            set
            {
                _yearDownValues = value;
                OnPropertyChanged("YearValues");
            }
        }
        private string _selectedYear;
        public string SelectedYear
        {
            get
            {
                return _selectedYear;
            }
            set
            {
                _selectedYear = value;
                OnPropertyChanged("SelectedYear");
            }
        }
