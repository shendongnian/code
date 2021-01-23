    public partial class MainWindow : Window
    {
        private Timer _timer = new Timer(TimerCallback, null, 100, 100);
        private static IAsyncResult _asyncResult;
        public MainWindow()
        {
            InitializeComponent();
        }
        static void LongRunTime()
        {
            Thread.Sleep(1000);
        }
        void Window_Loaded(object sender, RoutedEventArgs args)
        {
            Action myAction = () => LongRunTime();
            _asyncResult = myAction.BeginInvoke(myAction.EndInvoke, null);
        }
        static void TimerCallback(object obj)
        {
            if (_asyncResult != null)
            {
                bool called = ((dynamic)_asyncResult).EndInvokeCalled;
                if (called)
                {
                    // Will hit this breakpoint after LongRuntime has completed
                    Debugger.Break(); 
                    _asyncResult = null;
                }
            }
        }
    }
