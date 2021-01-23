    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
    private const int WM_SETREDRAW = 11;
    
    public static void SuspendDrawing(this Control Target)
    {
        SendMessage(Target.Handle, WM_SETREDRAW, false, 0);
    }
    
    public static void ResumeDrawing(this Control Target)
    {
        SendMessage(Target.Handle, WM_SETREDRAW, true, 0);
        Target.Invalidate();
        Target.Update();
    }
