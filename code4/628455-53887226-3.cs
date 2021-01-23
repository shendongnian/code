    internal class WindowHelp
    {
        private const int GWL_HWNDPARENT = -8;
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowLong(IntPtr hwnd, int index, int newStyle);
        public static void SetOwnerWindow(IntPtr hwndOwned, IntPtr intPtrOwner)
        {
            try
            {
                if (hwndOwned != IntPtr.Zero && intPtrOwner != IntPtr.Zero)
                {
                    SetWindowLong(hwndOwned, GWL_HWNDPARENT, intPtrOwner.ToInt32());
                }
            }
            catch { }
        }
    }
    WindowInteropHelper helper = new WindowInteropHelper(owner);
    _messageBox.Loaded += (sender, e) =>
    {
    	IntPtr windowHandleOwned = new WindowInteropHelper(_messageBox).Handle;
    	owner.Dispatcher.Invoke(new Action(() =>
    	{
    		WindowHelp.SetOwnerWindow(windowHandleOwned, helper.Handle);
    	}));
    };
