      using System.Diagnostics;
      using System.Runtime.InteropServices;
    // . . .
        [DllImport("user32.dll", SetLastError=true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
    // . . .
        uint excelAppPid;
        uint tid = GetWindowThreadProcessId(excel.Hwnd, out excelAppPid);
        if (tid)
        {
          Process excelAppProc = Process.GetProcessById($excelPid)
          if (excelAppProc)
          {
            excelAppProc.Kill()
          }
        }
