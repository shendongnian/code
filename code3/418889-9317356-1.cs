    public static int GetMessageProc(int code, IntPtr wParam, ref Message lParam)
    {
        if (code >= 0)
        {
            if (lParam.Msg == WM_CANCELJOURNAL)
            {
                // do something
            }
        }
        return CallNextHookEx(messageHook, code, 
    }
