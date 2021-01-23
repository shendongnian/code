    /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                this.DataContext = this;
                InitializeComponent();
    
                MenuItems = new ObservableCollection<KeyValuePair<string, ICommand>>();
                MenuItems.Add(new KeyValuePair<string, ICommand>("One", OneCommand));
                MenuItems.Add(new KeyValuePair<string, ICommand>("Two", null));
            }
    
            public ObservableCollection<KeyValuePair<String, ICommand>> MenuItems { get; set; }
    
            #region OneCommand
            DelegateCommand _OneCommand;
            public DelegateCommand OneCommand
            {
                get { return _OneCommand ?? (_OneCommand = new DelegateCommand(One, CanOne)); }
            }
    
            public bool CanOne()
            {
                return false;
            }
    
            public void One()
            {
    
            }
            #endregion
        }
