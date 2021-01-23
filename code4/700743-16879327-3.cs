    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            var worker = new BackgroundWorker();
            worker.DoWork += (s, e) =>
            {
                // Suppose we've done some processing and need to notify the UI.
                // We're on the background thread, so we can't manipulate the UI directly.
                this.Dispatcher.Invoke(new Action(() =>
                {
                    // This will actually run on the UI thread.
                    this.Label.Content = "hello from the background thread.";
                }));
            };
            worker.RunWorkerAsync();
        }
    }
