    class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    
        private ObservableCollection<string> _list = new ObservableCollection<string>();
        public ObservableCollection<string> List
        {
            get { return _list; }
            set 
            { 
                _list = value;
                NotifyPropertyChanged("List");
            }
        }
    
        public Model()
        {
            List.Add("why");
            List.Add("not");
            List.Add("these?");
        }
    }
