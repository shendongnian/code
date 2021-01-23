    [StructLayout(LayoutKind.Sequential)]
    public struct JournalHookStruct
    {
      public int message { get; set; }
      public int paramL { get; set; }
      public int paramH { get; set; }
      public int time { get; set; }
      public IntPtr hwnd { get; set; }
    }
    internal enum HookType
    {
      JournalRecord = 0,
      JournalPlayback = 1,
      KeyboardLowLevel = 20
    }
    internal enum HookCode
    {
      Action = 0,
      GetNext = 1,
      Skip = 2,
      NoRemove = 3,
      SystemModalOn = 4,
      SystemModalOff = 5
    }
    public const int HC_ACTION = 0;
    public const int LLKHF_EXTENDED = 0x1;
    public const int LLKHF_INJECTED = 0x10;
    public const int LLKHF_ALTDOWN = 0x20;
    public const int LLKHF_UP = 0x80;
    public const int VK_TAB = 0x9;
    public const int VK_CONTROL = 0x11;
    public const int VK_ESCAPE = 0x1B;
    public const int VK_DELETE = 0x2E;
    [DllImport("coredll.dll", SetLastError = true)]
    public static extern IntPtr SetWindowsHookEx(HookType idHook, HookProc lpfn, IntPtr hMod, int 
    [DllImport("coredll.dll", SetLastError = true)]
    public static extern bool UnhookWindowsHookEx(IntPtr hhk);
    [DllImport("coredll.dll", SetLastError = true)]
    public static extern int CallNextHookEx(IntPtr hhk, HookCode nCode, IntPtr wParam, IntPtr 
    [DllImport("coredll.dll", SetLastError = true)]
    public static extern IntPtr QASetWindowsJournalHook(HookType nFilterType, HookProc pfnFilterProc, ref JournalHookStruct pfnEventMsg);
