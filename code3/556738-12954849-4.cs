    public class Loader<TFuncResult>:FrameworkElement
    {
        private Func<TFuncResult> _execute;
        public TFuncResultResult { get; private set; }
        public delegate void OnJobFinished(object sender, TFuncResultresult);
        public event OnJobFinished JobFinished;
        public Loader(Func<TFuncResult> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
        }
        private Window GetWaitWindow()
        {
            Window waitWindow = new Window { Height = 100, Width = 200, WindowStartupLocation = WindowStartupLocation.CenterScreen, WindowStyle = WindowStyle.None };
            waitWindow.Content = new TextBlock { Text = "Please Wait", FontSize = 30, FontWeight = FontWeights.Bold, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            return waitWindow;
        }
        public void Load(Window waitWindow = null)
        {
            if (waitWindow == null)
            {
                waitWindow = GetWaitWindow();
            }
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                Dispatcher.BeginInvoke(new Action(delegate { waitWindow.ShowDialog(); }));
                Result = _execute();
                Dispatcher.BeginInvoke(new Action(delegate() { waitWindow.Close(); }));
            };
            worker.RunWorkerCompleted += delegate
            {
                worker.Dispose();
                if (JobFinished != null)
                {
                    JobFinished(this, Result);
                }
            };
            worker.RunWorkerAsync();
        }
    }
