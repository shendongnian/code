    public partial class Form1 : Form
    {
        private const uint WM_CLOSE = 0x0010;
        private IntPtr _myHandle;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            var t = new Thread(ThreadProc);
            t.Start();
        }
    
        protected override void OnHandleCreated(EventArgs e)
        {
            _myHandle = this.Handle;
            base.OnHandleCreated(e);
        }
    
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    
        private void ThreadProc(object o)
        {
            Thread.Sleep(5000);
            PostMessage(_myHandle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }
    }
