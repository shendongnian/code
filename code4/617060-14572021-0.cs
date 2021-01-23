    Process p = Process.Start(@"application.exe");
    
    p.WaitForInputIdle();
    IntPtr appWin = p.MainWindowHandle;
    
    SetParent(appWin, parent);
    SetWindowLong(appWin, GWL_STYLE, WS_VISIBLE);
    System.Threading.Thread.Sleep(100);
    MoveWindow(appWin, 0, 0, ClientRectangle.Width, ClientRectangle.Height, true);
