    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<bool> _LedStates;
    
        public List<bool> LedStates
        {
            get { return _LedStates; }
            set
            {
                _LedStates = value;
                NotifyPropertyChanged();
    
            }
        }
    
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LedStates = new List<bool>() {true, false, true};
        }
    
    
        #region INotifyPropertyChanged
        /// <summary>
        /// Event raised when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    
        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected virtual void NotifyPropertyChanged( [CallerMemberName] String propertyName = "" )
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler( this, new PropertyChangedEventArgs( propertyName ) );
            }
        } 
        #endregion
            
    }
