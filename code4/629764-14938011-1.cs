    public delegate void LoadTimeConsumingControlDelegate();
    public void LoadTimeConsumingControl()
        {
            //set our progress dialog text and value
            cctPlaceHolder.Content = new TimeConsumingControl();
        }
    private void Button_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            cctPlaceHolder.ContentTemplate = this.TryFindResource("loadingTemplate") as DataTemplate;
            System.Windows.Threading.Dispatcher cctDispatcher = cctPlaceHolder.Dispatcher;
            worker.DoWork += delegate(object s, DoWorkEventArgs args)
            {
                LoadTimeConsumingControlDelegate update = new LoadTimeConsumingControlDelegate(LoadTimeConsumingControl);
                cctDispatcher.BeginInvoke(update);
            };
            worker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs args)
            {
                cctPlaceHolder.ContentTemplate = null;
            };
            worker.RunWorkerAsync();
        }
