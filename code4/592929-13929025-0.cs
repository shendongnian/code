    class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string someText = string.Empty;
        public string SomeText
        {
            get { return this.someText; }
            set { this.someText = value; this.PropertyChanged(this, new PropertyChangedEventArgs("SomeText")); }
        }
    }
    class ViewModelA : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model data;
        public Model Data
        {
            get { return this.data; }
            set { this.data = value; this.PropertyChanged(this, new PropertyChangedEventArgs("Data")); }
        }
    }
    class ViewModelB : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model data;
        public Model Data
        {
            get { return this.data; }
            set { this.data = value; this.PropertyChanged(this, new PropertyChangedEventArgs("Data")); }
        }
    }
