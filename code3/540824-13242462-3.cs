    [DllImport("user32.dll", SetLastError = true)]
    private static extern int GetWindowThreadProcessId(IntPtr hwnd, ref int lpdwProcessId);
    
    ...
    
    if (xlApp != null)
    {
      GetWindowThreadProcessId(new IntPtr(xlApp.Hwnd), ref excelProcessId);
    
      Process ExcelProc = Process.GetProcessById(excelProcessId);
      if (ExcelProc != null)
      {
        ExcelProc.Kill();
      }
