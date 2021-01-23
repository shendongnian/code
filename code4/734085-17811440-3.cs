    public partial class MainWindow : Window
    {
        FocusNotifier focusNotifier;
        public MainWindow()
        {
            InitializeComponent();
            focusNotifier = new FocusNotifier(this);
            focusNotifier.OnFocusChanged += focusNotifier_OnFocusChanged;
        }
        void focusNotifier_OnFocusChanged(object sender, FocusNotifierEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.OldObject);
            System.Diagnostics.Debug.WriteLine(e.NewObject);
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            focusNotifier.Dispose();
            base.OnClosing(e);
        }
    }
