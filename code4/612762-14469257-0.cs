      public static class WindowsEnumerator
      {
        private static List<IntPtr> childs = new List<IntPtr>();
    
        public static List<WindowInfo> EnumerateChildWindows(IntPtr parentHandle)
        {
          var result = new List<WindowInfo>();
          childs.Clear();
          EnumChildWindows(parentHandle, Enumerator, IntPtr.Zero);
    
          foreach (IntPtr handle in childs)
          {
            result.Add(new WindowInfo(handle));  
          }
    
          return result;
        }
    
        private static bool Enumerator(IntPtr hwnd, IntPtr lparam)
        {
          childs.Add(hwnd);
          return true;
        }
    
        internal delegate bool WindowEnumProc(IntPtr hwnd, IntPtr lparam);
    
        [DllImport("user32.dll")]
        internal static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);
      }
    
      public class WindowInfo
      {
        public IntPtr Handle { get; private set; }
        public string Text { get; private set; }
        public string ClassName { get; private set; }
    
        public WindowInfo(IntPtr hwnd)
        {
          this.Handle = hwnd;
    
          var sb = new StringBuilder(1024);
          var txtLen = GetWindowText(this.Handle, sb, sb.Capacity);
          if (txtLen > 0)
            this.Text = sb.ToString();
          else
            this.Text = "";
    
    
          var sbc = new StringBuilder(256);
          var clsLen = GetClassName(this.Handle, sbc, sbc.Capacity);
          if (clsLen > 0)
            this.ClassName = sbc.ToString();
          else
            this.ClassName = "";
        }
    
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
      }
