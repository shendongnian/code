    private void settingsEvent_Click(object sender, EventArgs e)
        {
            if (gui == null)
            {
                gui = new App();
                gui.MainWindow = new mainWindow();
                gui.InitializeComponent();
            }
            else
            {
                gui.InitializeComponent();
                gui.MainWindow.Show();
                gui.MainWindow = new mainWindow();
            }
        }
        private static App app = new App();
