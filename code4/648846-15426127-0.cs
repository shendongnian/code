    public PageOneViewModel
    {
    
        private MainWindow _mainWindow;
        public PageOneViewModel(MainWindow mainWindow)
        {
             // Here I am saving MainWindow object.
             _mainWindow = mainWindow;
        }
    
        public OnNext()
        {
             // Here I am changing the view.
             MainWindow.DataContext = new PageTwoViewModel(_mainWindow);
        }
    }
