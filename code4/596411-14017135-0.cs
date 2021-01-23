    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool _myProperty = false;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public bool myProperty
        {
            get { return _myProperty; }
            set { _myProperty = value; NotifyPropertyChanged("myProperty"); }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            myProperty = !myProperty;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="property">The property name that changed.</param>
        public void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
