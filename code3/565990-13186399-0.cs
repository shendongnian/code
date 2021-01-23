    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Security;
     
    namespace Application
    {
    public class Program
    {
        public static void Main ( )
        {
            IntPtr hwnd = UnsafeNativeMethods.FindWindow("Notepad", null);
            StringBuilder stringBuilder = new StringBuilder(256);
            UnsafeNativeMethods.GetWindowText(hwnd, stringBuilder, stringBuilder.Capacity);
            Console.WriteLine(stringBuilder.ToString());
        }
    }
    [SuppressUnmanagedCodeSecurity]
    internal static class UnsafeNativeMethods
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern int GetWindowText ( IntPtr hWnd, [Out] StringBuilder lpString, int nMaxCount );
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindow ( string lpClassName, string lpWindowName );
    }
}
