    public partial class EntitiesView : UserControl, INotifyPropertyChanged
    {
        private string _name2;
        public string Name2
        {
            get { return _name2; }
            set
            {
                _name2 = value;
                RaisePropertyChanged("Name2");
            }
        }
        public EntitiesView()
        {
            Name2 = "abcdef";
            DataContext = this;
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
