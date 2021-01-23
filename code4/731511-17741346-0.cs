    async private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                await Task.Factory.StartNew(ExecuteSQL1);
                UpdateProgressBar(0);
                await Task.Factory.StartNew(ExecuteSQL2);
                UpdateProgressBar(0);            
            }
    private void ExecuteSQL1()
            {
                for (int i = 0; i < 100; i++)
                {
                    int progressBarValue = i;
                    Task.Factory.StartNew(() => UpdateProgressBar(progressBarValue), CancellationToken.None, TaskCreationOptions.None, uiScheduler);
                    Thread.Sleep(50);
                }
            }
     private void ExecuteSQL2()
            {
                for (int i = 0; i < 100; i++)
                {   
                    int progressBarValue = i;
                    Task.Factory.StartNew(() => UpdateProgressBar(progressBarValue), CancellationToken.None, TaskCreationOptions.None, uiScheduler);
                    Thread.Sleep(100);
                }
            }
    TaskScheduler uiScheduler;
    
            public MainWindow()
            {
                InitializeComponent();
    
                uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            }
