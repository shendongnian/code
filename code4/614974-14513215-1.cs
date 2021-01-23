    using System.Runtime.InteropServices;
    
    [DllImport("user32.dll")]
    
    public static extern bool  ExitWindowsEx(uint uFlags,uint dWReason);
    
    
    public static void Main()
    {
      ExitWindowsEx(2,4);
    }
