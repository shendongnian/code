      public class ViewModel: INotifyPropertyChanged
    {
        private bool _columnIsCollapsed;
        public ViewModel()
        {
            ColumnIsCollapsed = false;
            LoggedInUsers = new ObservableCollection<User>();
            LoggedInUsers.Add(new User(){FirstName = "SSSSSS", LastName = "XXXXXX"});
        }
        public bool ColumnIsCollapsed
        {
            get { return _columnIsCollapsed; }
            set
            {
                _columnIsCollapsed = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ColumnIsCollapsed"));
            }
        }
        public ObservableCollection<User> LoggedInUsers { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }
    public class User
    {
        public string ImageFile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
