    public partial class Form1 : Form
    {
        private const int WH_MOUSE_LL = 14;
        [DllImport("kernel32.dll")]
        static extern IntPtr GetModuleHandle(string moduleName);
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll")]
        public static extern int UnhookWindowsHookEx(IntPtr hhook);
        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, uint wParam, IntPtr lParam);
        delegate IntPtr HookProc(int nCode, uint wParam, IntPtr lParam);
        [StructLayout(LayoutKind.Sequential)]
        public struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public int mouseData; // be careful, this must be ints, not uints (was wrong before I changed it...). regards, cmew.
            public int flags;
            public int time;
            public UIntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }
        private HookProc hookProc;
        private IntPtr hook;
        private POINT formerPoint = new POINT() { X = 0, Y = 0 };
        public Form1() { InitializeComponent(); }
        IntPtr LowLevelMouseProc(int nCode, uint wParam, IntPtr lParam)
        {
            if (wParam == 0x200)
            {
                MSLLHOOKSTRUCT infoStr = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                if (infoStr.pt.X == formerPoint.X && infoStr.pt.Y == formerPoint.Y)
                {
                    Console.WriteLine("Mouse moved without coordinates changing");
                    //use the standard way of finding the direction of travel here.
                }
                formerPoint = infoStr.pt;
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            UnhookWindowsHookEx(hook);
            base.OnHandleDestroyed(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                hookProc = new HookProc(LowLevelMouseProc);
                hook = SetWindowsHookEx(WH_MOUSE_LL, hookProc, GetModuleHandle(null), 0);
            } 
        }
    }
