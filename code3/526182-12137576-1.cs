    public class SysMouseEventInfo : EventArgs
    {
        public string WindowTitle { get; set; }
    }
    public class RMouseListener
    {
        public RMouseListener()
        {
            this.CallBack += new HookProc(MouseEvents);
            //Module mod = Assembly.GetExecutingAssembly().GetModules()[0];
            //IntPtr hMod = Marshal.GetHINSTANCE(mod);
            using (Process process = Process.GetCurrentProcess())
            using (ProcessModule module = process.MainModule)
            {
                IntPtr hModule = GetModuleHandle(module.ModuleName);
                _hook = SetWindowsHookEx(WH_MOUSE_LL, this.CallBack, hModule, 0);
                //if (_hook != IntPtr.Zero)
                //{
                //    Console.WriteLine("Started");
                //}
            }
        }
        int WH_MOUSE_LL = 14;
        int HC_ACTION = 0;
        HookProc CallBack = null;
        IntPtr _hook = IntPtr.Zero;
        public event EventHandler<SysMouseEventInfo> RButtonClicked;
        int MouseEvents(int code, IntPtr wParam, IntPtr lParam)
        {
            //Console.WriteLine("Called");
            if (code < 0)
                return CallNextHookEx(_hook, code, wParam, lParam);
            if (code == this.HC_ACTION)
            {
                // Left button pressed somewhere
                if (wParam.ToInt32() == (uint)WM.WM_RBUTTONDOWN)
                {
                    MSLLHOOKSTRUCT ms = new MSLLHOOKSTRUCT();
                    ms = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                    IntPtr win = WindowFromPoint(ms.pt);
                    string title = GetWindowTextRaw(win);
                    if (RButtonClicked != null)
                    {
                        RButtonClicked(this, new SysMouseEventInfo { WindowTitle = title });
                    }
                }
            }
            return CallNextHookEx(_hook, code, wParam, lParam);
        }
        public void Close()
        {
            if (_hook != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_hook);
            }
        }
        public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);
    
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetWindowsHookEx", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(int xPoint, int yPoint);
        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(POINT Point);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [Out] StringBuilder lParam);
        public static string GetWindowTextRaw(IntPtr hwnd)
        {
            // Allocate correct string length first
            //int length = (int)SendMessage(hwnd, (int)WM.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
            StringBuilder sb = new StringBuilder(65535);//THIS COULD BE BAD. Maybe you shoudl get the length
            SendMessage(hwnd, (int)WM.WM_GETTEXT, (IntPtr)sb.Capacity, sb);
            return sb.ToString();
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MSLLHOOKSTRUCT
    {
        public POINT pt;
        public int mouseData;
        public int flags;
        public int time;
        public UIntPtr dwExtraInfo;
    }
    enum WM : uint
    {//all windows messages here
        WM_RBUTTONDOWN = 0x0204,
        WM_GETTEXT = 0x000D,
        WM_GETTEXTLENGTH = 0x000E
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
