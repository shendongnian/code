    C# Signature:
    public enum ShowCommands : int
    {
        SW_HIDE         = 0,
        SW_SHOWNORMAL       = 1,
        SW_NORMAL       = 1,
        SW_SHOWMINIMIZED    = 2,
        SW_SHOWMAXIMIZED    = 3,
        SW_MAXIMIZE     = 3,
        SW_SHOWNOACTIVATE   = 4,
        SW_SHOW         = 5,
        SW_MINIMIZE     = 6,
        SW_SHOWMINNOACTIVE  = 7,
        SW_SHOWNA       = 8,
        SW_RESTORE      = 9,
        SW_SHOWDEFAULT      = 10,
        SW_FORCEMINIMIZE    = 11,
        SW_MAX          = 11
    }
    [DllImport("shell32.dll")]
    static extern IntPtr ShellExecute(
    IntPtr hwnd,
    string lpOperation,
    string lpFile,
    string lpParameters,
    string lpDirectory,
    ShowCommands nShowCmd);
     // Asks default mail client to send an email to the specified address.
        ShellExecute( IntPtr.Zero, "open", "mailto:support@microsoft.com", "", "", ShowCommands.SW_SHOWNOACTIVATE    );
    
        // Asks default browser to visit the specified site.
        ShellExecute( IntPtr.Zero, "open", "http://channel9.msdn.com", "", "", ShowCommands.SW_SHOWNOACTIVATE );
    
        // Opens default HTML editing app to allow for edit of specified file
        ShellExecute( IntPtr.Zero, "edit", @"c:\file.html", "", "", ShowCommands.SW_SHOWNOACTIVATE );
       //Modified by Aljaz: Replaced the last zero in these calls with 4  otherwise it wouldn't show anything
       // 0 stands for SW_HIDE contant, which means execute but don't show the window which is probably not 
       // what we want.
