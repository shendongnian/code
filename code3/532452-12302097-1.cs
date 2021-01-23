        private static Splash splash = new Splash();
        
        // To refresh the UI immediately
        private delegate void RefreshDelegate();
        private static void Refresh(DependencyObject obj)
        {
            obj.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render,
                (RefreshDelegate)delegate { });
        }
        
        public Splash()
        {
            InitializeComponent();
        }
        public static void BeginDisplay()
        {
            splash.Show();
        }
        public static void EndDisplay()
        {
            splash.Close();
        }
        public static void Loading(string test)
        {
            splash.statuslbl.Content = test;
            Refresh(splash.statuslbl);
        }
        }
