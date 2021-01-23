    public partial class RunningForm : Form
    {
        #region Windows API - User32.dll
        [StructLayout(LayoutKind.Sequential)]
        public struct WinMessage
        {
            public IntPtr hWnd;
            public Message msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }
        [System.Security.SuppressUnmanagedCodeSecurity] // We won't use this maliciously
        [DllImport("User32.dll", CharSet=CharSet.Auto)]
        public static extern bool PeekMessage(out WinMessage msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);
        [System.Security.SuppressUnmanagedCodeSecurity] // We won't use this maliciously
        [DllImport("user32.dll")]
        public static extern int SendNotifyMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        #endregion
        Stopwatch sw;
        public event EventHandler RepeatTick;
        public RunningForm()
        {
            InitializeComponent();
            this.sw=new Stopwatch();
        }
        public void UpdateForm()
        {
            // Check if 200ms have passed
            if(sw.ElapsedMilliseconds>=200 )
            {
                if(this.RepeatTick!=null)
                {
                    this.RepeatTick(this, System.EventArgs.Empty);
                }
                sw.Reset();
                sw.Start();
            }
        }
        #region Main Loop
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            sw.Start();
            // Hook the application's idle event
            System.Windows.Forms.Application.Idle+=new EventHandler(OnApplicationIdle);
            this.RepeatTick+=new EventHandler(RunningForm_RepeatTick);
        }
        void RunningForm_RepeatTick(object sender, EventArgs e)
        {
            textBox1.AppendText("|");
        }
        private void OnApplicationIdle(object sender, EventArgs e)
        {
            while(AppStillIdle)
            {
                if(checkBox1.Checked)
                {
                    UpdateForm();
                }
            }
        }
        private bool AppStillIdle
        {
            get
            {
                WinMessage msg;
                return !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
            }
        }
        #endregion
    }
