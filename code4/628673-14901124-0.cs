    private static int WM_QUERYENDSESSION = 0x11;
    private static bool systemShutdown = false;
    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
        if (m.Msg == WM_QUERYENDSESSION)
        {
            systemShutdown = true;
        }
    
        // If this is WM_QUERYENDSESSION, the closing event should be
        // raised in the base WndProc.
        base.WndProc(ref m);
    
    }
