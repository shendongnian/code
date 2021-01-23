    public class Window : Win32
    {
        public IntPtr Handle;
    
        public Window(IntPtr handle)
        {
            Handle = handle;
        }
    
        public bool Visible
        {
            get { return IsWindowVisible(Handle); }
            set
            {
                ShowWindow(Handle, value ? ShowWindowConsts.SW_SHOW :
                    ShowWindowConsts.SW_HIDE);
            }
        }
    
        public void Show() 
        { 
            Visible = true;
            SetForegroundWindow(Handle);
            /*
            try { SwitchToThisWindow(Handle, false); } // this is deprecated - may throw on new window platform someday
            catch { SetForegroundWindow(Handle); } // 
            */
        }
    
        public void Hide() { Visible = false; }
    }
