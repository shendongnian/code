    public MainWindow()
    {
        InitializeComponent();
        
        VisualWrapper visualWrapper = (VisualWrapper)this.FindName("visualWrapper");
    
        LoadingPanel loadingPanel = new LoadingPanel(visualWrapper);
    
        Dispatcher.Invoke((Action)(() =>
        {
            loadingPanel.ShowWaitDialog();
        }), DispatcherPriority.Send, null);
        
         Task.Factory.StartNew(() =>
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 14000; i++)
            {
                list.Add("Item number" + i);
            }
            Dispatcher.BeginInvoke((Action)(() =>
            {
                Cb.ItemsSource = list;
            }), DispatcherPriority.Normal, null);
        }, TaskCreationOptions.LongRunning);
    }
