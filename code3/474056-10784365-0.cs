    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam); 
    const int LB_GETCOUNT = 0x018B;
    const int LB_GETTEXT = 0x0189;
    
    private List<string> GetListBoxContents(IntPtr listBoxHwnd)
    {
      int cnt = (int)SendMessage(listBoxHwnd, LB_GETCOUNT, IntPtr.Zero, null);
      List<string> listBoxContent = new List<string>();
      for (int i = 0; i < cnt; i++)
      {
        StringBuilder sb = new StringBuilder(256);
        IntPtr getText = SendMessage(listBoxHwnd, LB_GETTEXT, (IntPtr)i, sb);
        listBoxContent.Add(sb.ToString());
      }
      return listBoxContent;
    }
