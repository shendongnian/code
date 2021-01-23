    using System.Runtime.InteropServices;
    // ...
    // Inside a class:
    [DllImport("user32.dll")]
    private static extern uint GetWindowThreadProcessId(
        IntPtr hWnd, out uint lpdwProcessId);
    
    // Returns "true" on success, "false" on failure.
    public static bool KillExcel(Application excel) {
        uint processId;
        GetWindowThreadProcessId((IntPtr)excel.Hwnd, out processID);
        try {
            Process.GetProcessById((int)processID).Kill()
        
        } catch (Exception /* TODO: catch only relevant exceptions */) {
            return false;
        }
        
        return true;
    }
   
