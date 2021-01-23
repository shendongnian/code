    public class CoTableLayoutPanel : TableLayoutPanel
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.CacheText, true);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= NativeMethods.WS_EX_COMPOSITED;
                return cp;
            }
        }
        public void BeginUpdate()
        {
            NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
        }
        public void EndUpdate()
        {
            NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
            Parent.Invalidate(true);
        }
    }
    public static class NativeMethods
    {
        public static int WM_SETREDRAW = 0x000B; //uint WM_SETREDRAW
        public static int WS_EX_COMPOSITED = 0x02000000; 
      
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam); //UInt32 Msg
    }
