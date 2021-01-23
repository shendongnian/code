            #region MM keyboard
            [DllImport("GlobalCbtHook.dll")]
            public static extern bool InitializeShellHook(int threadID, IntPtr DestWindow);
            [DllImport("GlobalCbtHook.dll")]
            public static extern void UninitializeShellHook();
            [DllImport("user32.dll")]
            public static extern int RegisterWindowMessage(string lpString);
    
            private const int FAPPCOMMAND_MASK = 0xF000;
    
            private const int APPCOMMAND_MEDIA_NEXTTRACK     = 11;
            private const int APPCOMMAND_MEDIA_PREVIOUSTRACK = 12;
            private const int VK_MEDIA_STOP                  = 13;
            private const int VK_MEDIA_PLAY_PAUSE            = 14;
    
            private int AppCommandMsgId;
            private HwndSource SenderHwndSource;
    
            private void _SetMMHook()
            {
                AppCommandMsgId = RegisterWindowMessage("WILSON_HOOK_HSHELL_APPCOMMAND");
                var hwnd = new WindowInteropHelper(Sender).Handle;
                InitializeShellHook(0, hwnd);
                SenderHwndSource = HwndSource.FromHwnd(hwnd);
                SenderHwndSource.AddHook(WndProc);
            }
    
            private static int HIWORD(int p) { return (p >> 16) & 0xffff; }
    
            public IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
            {
                if (msg == AppCommandMsgId)
                {
                    int keycode = HIWORD(lParam.ToInt32()) & ~FAPPCOMMAND_MASK; //#define GET_APPCOMMAND_LPARAM(lParam) ((short)(HIWORD(lParam) & ~FAPPCOMMAND_MASK))
                    // Do work
                    Debug.WriteLine(keycode);
                    if (OnKeyMessage != null)
                    {
                        OnKeyMessage(null, EventArgs.Empty);
                    }
                }
                return IntPtr.Zero;
            }
            #endregion
    
            #region Managed
            private readonly Window Sender;
    
            private KeyboardHook() { }
            public KeyboardHook(Window sender)
            {
                Sender = sender;
            }
    
            public void SetMMHook()
            {
                _SetMMHook();
            }
    
            public event EventHandler OnKeyMessage;
    
            private bool Released = false;
            public void ReleaseAll()
            {
                if (Released) return;
                UninitializeShellHook();
                SenderHwndSource.RemoveHook(WndProc);
                Released = true;
            }
    
            ~KeyboardHook()
            {
                ReleaseAll();
            }
            #endregion
