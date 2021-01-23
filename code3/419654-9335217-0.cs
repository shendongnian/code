    public static class HWND {
      public static readonly IntPtr
      NOTOPMOST = new IntPtr(-2),
      BROADCAST = new IntPtr(0xffff),
      TOPMOST = new IntPtr(-1),
      TOP = new IntPtr(0),
      BOTTOM = new IntPtr(1);
    }
    public static class SWP {
      public static readonly int
      NOSIZE = 0x0001,
      NOMOVE = 0x0002,
      NOZORDER = 0x0004,
      NOREDRAW = 0x0008,
      NOACTIVATE = 0x0010,
      DRAWFRAME = 0x0020,
      FRAMECHANGED = 0x0020,
      SHOWWINDOW = 0x0040,
      HIDEWINDOW = 0x0080,
      NOCOPYBITS = 0x0100,
      NOOWNERZORDER = 0x0200,
      NOREPOSITION = 0x0200,
      NOSENDCHANGING = 0x0400,
      DEFERERASE = 0x2000,
      ASYNCWINDOWPOS = 0x4000;
    }
    [DllImport("user32.dll")]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
    private void button1_Click(object sender, EventArgs e) {
      RunnerForm frm = new RunnerForm();
      SetWindowPos(frm.Handle, HWND.BOTTOM, 0, 0, 0, 0, SWP.SHOWWINDOW | SWP.NOMOVE | SWP.NOOWNERZORDER | SWP.NOSIZE | SWP.NOACTIVATE);
    }
