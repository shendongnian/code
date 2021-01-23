    public Class
    {
        private MainWindow window;
        public Class(MainWindow mainWindow)
        {
            window = mainWindow;
        }
        public void MyMethod()
        {
            window.lblTag.Content = "Content";
        }
    }
