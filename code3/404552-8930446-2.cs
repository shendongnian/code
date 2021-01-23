    public static class Win32 {
      public const int WM_SETREDRAW = 0x0b;
      [DllImport("user32.dll")]
      public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
      public static void SuspendPainting(IntPtr hWnd) {
        SendMessage(hWnd, WM_SETREDRAW, (IntPtr)0, IntPtr.Zero);
      }
      public static void ResumePainting(IntPtr hWnd) {
        SendMessage(hWnd, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
      }
    }
