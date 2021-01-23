    [DllImport("user32")]
    private static extern int GetWindowLong(IntPtr hwnd, int nIndex);
    public static class ControlExtension {
       public static bool IsRightToLeft(this Control c){
         return (GetWindowLong(c.Handle,-20) & 0x1000) != 0;//GWL_EXSTYLE = -20
       }
    }
