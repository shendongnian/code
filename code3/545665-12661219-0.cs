    public class Profile
    {
        private string _name;        
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }
    
    
        private readonly ObservableCollection<SomeData> _data = new ObservableCollection<SomeData>();
        public ObservableCollection<SomeData> Data
        {
            get { return _data; }
        }
    
        public Profile()
        {
        }
    }
