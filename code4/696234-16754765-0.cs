    public class Global : INotifyPropertyChanged
    {
        private static Global _instance = new Global();
        public static Global Instance { get { return _instance; } }
        private ObservableCollection<string, Dictionary<string, Dictionary<string, object>>> operations = new ObservableCollection<string, Dictionary<string, Dictionary<string, object>>>();
        public ObservableCollection<string> _Operations
        {
            get
            {
                // ...
            }
            set
            {
                // ...
                OnPropertyChanged("_Operations");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName);
        }
    }
