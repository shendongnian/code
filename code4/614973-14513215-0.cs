    using System.Runtime.InteropServices;
    
    [DllImport("user32.dll")]
    
    public static extern bool  ExitWindowsEx(uint f,long int r);
    
    
    public static void Main()
    {
      ExitWindowsEx(2,4);
    }
