    public partial class MyClass : INotifyPropertyChanged
    {
        ObservableCollection<string> _items;
        public MyClass()
        {
            _items = new ObservableCollection<string>();
            _items.CollectionChanged += (s, e) => { OnPropertyChanged("Items"); };
        }
        public IEnumerable<string> Items 
        { 
            get 
            {
                yield return "first value";
                foreach (var item in _items.OrderBy(x=>x))
                    yield return item;
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
    
