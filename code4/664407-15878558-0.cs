        public MainWindow()
        {
            InitializeComponent();
            this.Closing+=new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
            
        }
        private void MainWindow_Closing(object sender, EventArgs e)
        {
            MessageBox.Show("salman");
        }
