    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Strings = new ObservableCollection<string>();
            for (int i = 0; i < 50; i++)
            {
                Strings.Add("Value " + i);
            }
        }
        public ObservableCollection<string> Strings { get; set; }
        private string _selectedString;
        public string SelectedString
        {
            get { return _selectedString; }
            set
            {
                if (value == _selectedString) return;
                _selectedString = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
