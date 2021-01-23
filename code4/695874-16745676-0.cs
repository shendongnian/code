    [StructLayout(LayoutKind.Sequential)]
    public struct KBDLLHOOKSTRUCT
    {
        public uint vkCode;
        public uint scanCode;
        public uint flags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
    public delegate IntPtr LowLevelKeyboardProc(int, IntPtr, KBDLLHOOKSTRUCT);
    [DllImport("kernel32.dll")]
    public static extern uint GetCurrentThreadId();
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool UnhookWindowsHookEx(IntPtr hhk);
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr SetWindowsHookEx(int idhook, LowLevelKeyboardProc proc, IntPtr hMod, uint threadId);
    [DllImport("user32.dll")]
    static extern int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);
    public static IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (var curProc = Process.GetCurrentProcess())
        using (var curMod = curProc.MainModule)
        {
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curMod.ModuleName), 0u);
        }
    }
    public IntPtr MyKeyboardHook(int code, IntPtr wParam, ref KBDLLHOOKSTRUCT keyboardInfo)
    {
        if (code < 0)
        {
            return CallNextHookEx(IntPtr.Zero, wParam, ref keyboardInfo);
        }
        // Do your thing with the keyboard info.
        return CallNextHookEx(IntPtr.Zero, code, wParam, ref keyboardInfo);
    }
