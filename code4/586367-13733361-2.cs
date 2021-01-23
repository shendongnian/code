    public MainWindow()
        {
            SourceInitialized += Window_SourceInitialized;
            InitializeComponent();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            WindowInteropHelper wih = new WindowInteropHelper(this);
            int style = GetWindowLong(wih.Handle, GWL_STYLE);
            SetWindowLong(wih.Handle, GWL_STYLE, style & ~WS_SYSMENU);
        }
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x00080000;
        [DllImport("user32.dll")]
        private extern static int SetWindowLong(IntPtr hwnd, int index, int value);
        [DllImport("user32.dll")]
        private extern static int GetWindowLong(IntPtr hwnd, int index);
