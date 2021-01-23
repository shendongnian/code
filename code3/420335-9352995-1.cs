        public MainWindow() {
            InitializeComponent();
            enableMenuTabs(false);
            menu1.PreviewGotKeyboardFocus += delegate { enableMenuTabs(true); };
            menu1.PreviewLostKeyboardFocus += delegate { enableMenuTabs(false); };
        }
        private void enableMenuTabs(bool enable) {
            foreach (Control item in menu1.Items) item.IsTabStop = enable;
        }
