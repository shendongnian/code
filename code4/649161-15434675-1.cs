    public sealed class HotkeyManager : NativeWindow, IDisposable
    {
    	public HotkeyManager()
        {
            CreateHandle(new CreateParams());
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY)
            {
                 //handle hotkey message
            }
            base.WndProc(ref m);
        }
        public void Dispose()
        {
            DestroyHandle();
        }
    }
