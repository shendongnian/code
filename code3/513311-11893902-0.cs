    public class WinAPI {
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
        public const int GWL_HWNDPARENT = -8;
    }
    WinAPI.SetWindowLong(this.Handle, WinAPI.GWL_HWNDPARENT, (uint)this.ObservedHandle);
           
