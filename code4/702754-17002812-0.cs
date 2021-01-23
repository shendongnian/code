    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
        const int WM_SIZE = 5;
        const int SIZE_MAXIMIZED = 2;
        const int SW_RESTORE = 9;
    
        public Form1()
        {
            InitializeComponent();
    
            FormBorderStyle = FormBorderStyle.None;
        }
    
        protected override void WndProc(ref Message msg)
        {
            switch (msg.Msg)
            {
                case WM_SIZE:
                    if ((int)msg.WParam == SIZE_MAXIMIZED)
                    {
                        msg.Result = IntPtr.Zero;
                        ShowWindow(this.Handle, SW_RESTORE);
                        return;
                    }
                    break;
            }
    
            base.WndProc(ref msg);
        }
    }
