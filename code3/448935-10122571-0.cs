    public static class WinWordKiller
    {
            [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true,
    CharSet = CharSet.Unicode, ExactSpelling = true,
    CallingConvention = CallingConvention.StdCall)]
        private static extern long GetWindowThreadProcessId(long hWnd, out long lpdwProcessId);
    
        public static void Kill(ref Microsoft.Office.Interop.Word.Application app)
        {
            long processId = 0;
            long appHwnd = (long)app.Hwnd;
    
            GetWindowThreadProcessId(appHwnd, out processId);
    
            Process prc = Process.GetProcessById((int)processId);
            prc.Kill();
        }
    }
