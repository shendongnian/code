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
            for (int i = 0; i < 14000; i++)
            {
                Cb.Items.Add("Item number" + i);
            }
        }, TaskCreationOptions.LongRunning);
    }
