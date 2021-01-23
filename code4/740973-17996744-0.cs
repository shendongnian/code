    public class Alpha : INotifyPropertyChanged
    {
        private ObservableCollection<Beta> items = new ObservableCollection<Beta>();
        public ObservableCollection<Beta> Items
        {
            get
            {
                return items;
            } 
            set
            {
                items = value;
                RaisePropertyChanged("Items");
            }
        }
    
        public Alpha() 
        { 
            DoSomething();
        }
    
        public void DoSomething()
        {
            Items = GetNewItems();
        }
    
        public ObservableCollection<Beta> GetNewItems()
        {
             var ret = new ObservableCollection<Beta>();
             return ret;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
