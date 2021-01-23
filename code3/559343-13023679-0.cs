    public partial class MainWindow : Window
    {
        private int SC_MINIMIZE = 0xf020;
        private int SYSCOMMAND = 0x0112;
        public MainWindow()
        {
            InitializeComponent();
            SourceInitialized += (sender, e) =>
                                     {
                                         HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
                                         source.AddHook(WndProc);
                                     };
        }
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            // process minimize button
            if (msg == SYSCOMMAND && SC_MINIMIZE == wParam.ToInt32())
            {
                //Minimize clicked
                handled = true;
            }
            return IntPtr.Zero;
        }
    }
