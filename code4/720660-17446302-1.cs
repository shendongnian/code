    IntPtr theHandle = WindowFromPoint(Cursor.Position.X, Cursor.Position.Y);
    if (theHandle != null)
    {
       long res;
       res = Win32.SendMessage(theHandle, Win32.WM_GETTEXTLENGTH, 0, null);
       int len = (int)res;
       StringBuilder sb = new StringBuilder(len+1);
       strTemp = sb.ToString();
       int x = strTemp.Length;
       res = Win32.SendMessage(theHandle, Win32.WM_GETTEXT,(uint)len + 1 , strTemp);
       Clipboard.SetText(strTemp);
    }
