    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool vis;
        public bool Vis
        {
            get { return vis; }
            set
            {
                if (vis != value)
                {
                    vis = value;
                    OnPropertyChanged("Vis");  // To notify when the property is changed
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Vis = true;
            DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Vis = !Vis;  // Test Code
        }
        #region INotifyPropertyChanged implementation
        // Basically, the UI thread subscribes to this event and update the binding if the received Property Name correspond to the Binding Path element
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
