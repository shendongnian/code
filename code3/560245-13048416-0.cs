    [DllImport("user32")] public static extern int GetCursorPos(ref POINTAPI lpPoint)
    [DllImport("user32")] public static extern int SendMessage(ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As Integer)
    [DllImport("user32")] public static extern int WindowFromPoint(int xPoint, int yPoint)
    
    const object WM_GETTEXT = 13;
    const object WM_GETTEXTLENGTH = 14;
    
    POINTAPI P;
    long lRet;
    long hHandle;
    string aText;
    long lTextlen;
    string aText;
    lRet = GetCursorPos(P);
    hHandle = WindowFromPoint(P.x, P.y);
    lTextlen = SendMessage(hHandle, WM_GETTEXTLENGTH, 0, 0);
    if (lTextlen)
    {
    	 if (lTextlen > 1024) lTextlen = 1024; 
    	 lTextlen += 1
    	 aText = Space(lTextlen);
    	 lRet = SendMessage(hHandle, WM_GETTEXT, lTextlen, aText);
    	 aText = aText.Substring(lRet);
    }
