    namespace CascadingDataGrids
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            #region Members
    
            private readonly DemoViewModel _vm;
    
            #endregion
    
            #region Constructors
    
            /// <summary>
            /// Initializes a new instance of the <see cref="MainWindow"/> class.
            /// </summary>
            public MainWindow()
            {
                // Set viewmodel
                _vm = new DemoViewModel();
    
                // Set data context
                this.DataContext = _vm;
    
                // Initialize UI
                InitializeComponent();
            }
    
            #endregion
        }
    }
