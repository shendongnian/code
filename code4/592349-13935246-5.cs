    private static int WM_QUERYENDSESSION = 0x11;
    private static bool systemShutdown = false;
    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
        if (m.Msg==WM_QUERYENDSESSION)
        {
            systemShutdown = true;
        }
        base.WndProc(ref m);
    
    }
