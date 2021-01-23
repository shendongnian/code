    class classViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private IDictionary<string, object> Variables { get; set; } = new ConcurrentDictionary<string, object>();
        private DictionaryPropertyGridAdapter<string, object> _selectedObj;
        public DictionaryPropertyGridAdapter<string, object> SelectedObj
        {
            get
            {
                this.Variables["Bool"] = false;
                this.Variables["Int"] = 200;
                this.Variables["Float"] = 200.5;
                this.Variables["String"] = "help";
                _selectedObj = new DictionaryPropertyGridAdapter<string, object>(this.Variables);
                return _selectedObj;
            }
            set {
                _selectedObj = value;
                OnPropertyChanged(nameof(this.SelectedObj));
            }
        }
    }
