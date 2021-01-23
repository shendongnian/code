    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            GridData = new GridData { Results = new ObservableCollection<PersonName>() };
            GridData.Results.Add(new PersonName { Name = "Test1" });
            GridData.Results.Add(new PersonName { Name = "Test2" });
        }
    
        private GridData _gridData;
        public GridData GridData
        {
            get { return _gridData; }
            set { _gridData = value; NotifyPropertyChanged("GridData"); }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="info">The info.</param>
        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
