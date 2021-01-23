     public static class ProcessSpy
      {
        public static List<ProcessSpyData> GetDataForProcess(string processName)
        {
          var result = new List<ProcessSpyData>();
          Process myProc = Process.GetProcessesByName(processName).FirstOrDefault();
          if (myProc != null)
          {
            var myHandles = EnumerateProcessWindowHandles(myProc);
            foreach (IntPtr wndHandle in myHandles)
            {
              result.Add(new ProcessSpyData(wndHandle));
            }
          }
          return result;
        }
    
        delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);
    
        [DllImport("user32.dll")]
        static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);
    
        static IEnumerable<IntPtr> EnumerateProcessWindowHandles(Process prc)
        {
          var handles = new List<IntPtr>();
    
          foreach (ProcessThread thread in prc.Threads)
            EnumThreadWindows(thread.Id, (hWnd, lParam) => { handles.Add(hWnd); return true; }, IntPtr.Zero);
    
          return handles;
        }
      }
    
      public class ProcessSpyData
      {
        private const uint WM_GETTEXT = 0x000D;
    
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);
    
        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);
    
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
          int left, top, right, bottom;
    
          public Rectangle ToRectangle()
          {
            return new Rectangle(left, top, right - left, bottom - top);
          }
        }
    
        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);
    
        public IntPtr WindowHandle { get; private set; }
        public string WindowText { get; private set; }
        public Rectangle ClientRect { get; private set; }
        public Rectangle ScreenPos { get; private set; }
    
        public ProcessSpyData(IntPtr windowHandle)
        {
          this.WindowHandle = windowHandle;
          GetWindowText();
          GetWindowSize();
        }
    
        private void GetWindowText()
        {
          StringBuilder message = new StringBuilder(1024);
          SendMessage(this.WindowHandle, WM_GETTEXT, message.Capacity, message);
          this.WindowText = message.ToString();
        }
    
        private void GetWindowSize()
        {
          var nativeRect = new RECT();
          GetClientRect(this.WindowHandle, out nativeRect);
          this.ClientRect = nativeRect.ToRectangle();
    
          Point loc = this.ClientRect.Location;
          ClientToScreen(this.WindowHandle, ref loc);
          this.ScreenPos = new Rectangle(loc, this.ClientRect.Size);
        }
      }
