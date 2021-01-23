    public partial class LoadingViewControl : Window
    {
        public LoadingViewControl(string userName, string password)
        {
            InitializeComponent();
            Initialize(userName, password);
        }
        private void Initialize(string userName, string password)
        {
            pbProcessing.IsIndeterminate = true;
            var thread = new Thread(() =>
                                        {
                                            DialogResult = User.Instance.Authenticicate(userName, password);
                                            Close();
                                        });
            thread.IsBackground = true;
            thread.Start();
        }
    }
