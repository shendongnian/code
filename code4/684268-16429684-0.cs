    public partial class Form1 : Form
    {
        private const int WM_HOTKEY = 0x0312;
        private const int WM_DESTROY = 0x0002;
        
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        public Form1()
        {
            InitializeComponent();
            RegisterHotKey(this.Handle, 1001, 1, (int)Keys.D1);
            RegisterHotKey(this.Handle, 1002, 1, (int)Keys.D2);
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 1001:
                            Console.Write("alt+1");
                            break;
                        case 1002:
                            Console.Write("alt+2");
                            break;
                    
                    }
                    break;
                case WM_DESTROY:
                    UnregisterHotKey(this.Handle, 1001);
                    UnregisterHotKey(this.Handle, 1002);
                    break;
            }
            base.WndProc(ref m);
        }
    }
