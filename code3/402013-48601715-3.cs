    [DebuggerHidden, DebuggerStepperBoundary, DebuggerNonUserCode, DllImport("user32.dll", EntryPoint = "PeekMessage")]
    public static extern int PeekMessage(out NativeMessage lpMsg, IntPtr hWnd, int wMsgFilterMin, int wMsgFilterMax, int wRemoveMsg);
    [DebuggerHidden, DebuggerStepperBoundary, DebuggerNonUserCode, DllImport("user32.dll", EntryPoint = "GetMessage")]
    public static extern int GetMessage(out NativeMessage lpMsg, IntPtr hWnd, int wMsgFilterMin, int wMsgFilterMax);
    [DebuggerHidden, DebuggerStepperBoundary, DebuggerNonUserCode, DllImport("user32.dll", EntryPoint = "TranslateMessage")]
    public static extern int TranslateMessage(ref NativeMessage lpMsg);
    [DebuggerHidden, DebuggerStepperBoundary, DebuggerNonUserCode, DllImport("user32.dll", EntryPoint = "DispatchMessage")]
    public static extern int DispatchMessage(ref NativeMessage lpMsg);
    [DebuggerHidden, DebuggerStepperBoundary, DebuggerNonUserCode]
    public static bool ProcessMessageOnce()
    {
        NativeMessage message = new NativeMessage();
        if (!IsMessagePending(out message))
            return true;
        if (GetMessage(out message, IntPtr.Zero, 0, 0) == -1)
            return true;
        Message frameworkMessage = new Message()
        {
            HWnd = message.handle,
            LParam = message.lParam,
            WParam = message.wParam,
            Msg = (int)message.msg
        };
        if (Application.FilterMessage(ref frameworkMessage))
            return true;
        TranslateMessage(ref message);
        DispatchMessage(ref message);
        return false;
    }
