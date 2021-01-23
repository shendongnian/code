    public class ViewModel: INotifyPropertyChanged
    {
        // Declare the event 
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private ObservableCollection<Dummy> _dummyCollection;
        public ObservableCollection<Dummy> DummyCollection 
        {
            get { return _dummyCollection; }
            set
            {
                // Set the value and then inform the ViewModel about change with OnPropertyChanged
                _dummyCollection = value;
                OnPropertyChanged("DummyCollection");
            }
        }
    }
