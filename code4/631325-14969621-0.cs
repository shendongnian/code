        public MainWindow()
        {
            // Subscribe to closing event (when X is pressed)
            this.Closing += MainWindow_Closing;
            InitializeComponent();
        }
        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Prevent window from closing
            e.Cancel = true;
            // Hide window
            this.Hide();
        }
