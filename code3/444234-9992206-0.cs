      public static void RemoveAppBar(Window appbarWindow)
            {
                RegisterInfo info = GetRegisterInfo(appbarWindow);
    
                if (info.IsRegistered)
                {
                    APPBARDATA abd = new APPBARDATA();
                    abd.cbSize = Marshal.SizeOf(abd);
                    abd.hWnd = new WindowInteropHelper(appbarWindow).Handle;
                    SHAppBarMessage((int)ABMsg.ABM_REMOVE, ref abd);
                }
            }
