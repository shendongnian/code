    public partial class Form1 : Form
    {
        [DllImport("User32")]
        private static extern int SetForegroundWindow(IntPtr hwnd);
        public Form1()
        {
            InitializeComponent();
            Process notepad = Process.GetProcessesByName("notepad").FirstOrDefault();
            if (notepad != null)
            {
                SetForegroundWindow(notepad.MainWindowHandle);
                SendKeys.SendWait("test");
            }
        }
    }
