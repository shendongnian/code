    ...
    DispatcherHelper.Initialise()
    ...
    private ObservableCollection<BitmapImage> _Pages = new ObservableCollection<BitmapImage>();
    public PagesListBox()
    {
        InitializeComponent();
        BackgroundWorker worker = new BackgroundWorker();
        worker.WorkerSupportsCancellation = false;
        worker.WorkerReportsProgress = false;
        worker.DoWork += worker_DoWork;
        this.ItemSource = _Pages;
    }
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
         var files = DirectoryServices.GetFiles(Properties.Settings.Default.PagesScanDirectory, new string[] { "*.tiff", "*.jpg", "*.png", "*.bmp" });
        foreach (var file in files)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(()=>
            {
                Uri uri = new Uri(file);
                _Pages.Add(new BitmapImage(uri));
            });
        }
    }
    public static class DispatcherHelper
    {
        public static Dispatcher UIDispatcher { get; private set; }
        public static void CheckBeginInvokeOnUI(Action action)
        {
            if (UIDispatcher.CheckAccess())
                action();
            else
                UIDispatcher.BeginInvoke(action);
        }
        public static void Initialize()
        {
            if (UIDispatcher != null)
                return;
            UIDispatcher = Dispatcher.CurrentDispatcher;
        }
    }
