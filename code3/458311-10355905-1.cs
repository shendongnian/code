       [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
          public int X;
          public int Y;    
          public static implicit operator Point(POINT point)
          {
            return new Point(point.X, point.Y);
          }
        }
        
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);    
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);    
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);   
        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);
