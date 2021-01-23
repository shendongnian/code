    // Code was burrowed from:
    //   http://stackoverflow.com/questions/19867402/how-can-i-use-enumwindows-to-find-windows-with-a-specific-caption-title
    //   http://www.dotnetframework.org/default.aspx/4@0/4@0/DEVDIV_TFS/Dev10/Releases/RTMRel/ndp/fx/src/CommonUI/System/Drawing/NativeMethods@cs/1305376/NativeMethods@cs
    //   http://stackoverflow.com/questions/7292757/how-to-get-screenshot-of-a-window-as-bitmap-object-in-c
    //   http://stackoverflow.com/questions/798295/how-can-i-use-getnextwindow-in-c */
    public static class WinAPI
    {
       public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        };
        public enum GW
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }
        [DllImport("User32.dll")]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);
        [DllImport("User32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("User32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("User32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);
        [DllImport("User32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, ref RECT lpRect);
        [DllImport("User32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [DllImport("User32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("User32.dll")]
        public static extern IntPtr GetTopWindow(IntPtr hWnd);
        public static IntPtr GetNextWindow(IntPtr hWnd, GW wCmd)
        {
            return GetWindow(hWnd, wCmd);
        }
        public static IntPtr GetWindow(IntPtr hWnd, GW wCmd)
        {
            return GetWindow(hWnd, (uint)wCmd);
        }
        [DllImport("User32.dll")]
        private static extern IntPtr GetWindow(IntPtr hWnd, uint wCmd);
        [DllImport("User32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, uint nFlags);
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("Gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hdc);
        [DllImport("User32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("User32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hdc);
        [DllImport("User32.dll")]
        public static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);
        [DllImport("Gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hWnd);
        [DllImport("Gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int width, int height);
        [DllImport("Gdi32.dll")]
        public static extern IntPtr CreateBitmap(int width, int height, uint cPlanes, uint cBitsPerPel, IntPtr lpvBits);
        [DllImport("Gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hGdiObj);
        [DllImport("Gdi32.dll")]
        public static extern bool SelectObject(IntPtr hdc, IntPtr hGdiObj);
        [DllImport("Gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        public static StringBuilder GetWindowText(IntPtr hWnd)
        {
            int length = GetWindowTextLength(hWnd);
            // Add another place to allow null terminator
            StringBuilder text = new StringBuilder(length + 1);
            GetWindowText(hWnd, text, length + 1);
            return text;    
        }
        public static bool IsWindowReallyVisible(IntPtr hWnd)
        {
            if (!IsWindowVisible(hWnd) || IsIconic(hWnd))
                return false;
            RECT area = new RECT();
            if (!GetWindowRect(hWnd, ref area))
                return true;
            if (area.left == area.right || area.bottom == area.top)
                return false;
            return true;
        }
        public enum RegionFlags
        {
            ERROR = 0,
            NULLREGION = 1,
            SIMPLEREGION = 2,
            COMPLEXREGION = 3,
        } 
    }
    
    public class ScreenShot
    {
        public static List<IntPtr> GetAllWindows(Func<IntPtr, bool> filter, Func<IntPtr, bool> stop)
        {
            List<IntPtr> result = new List<IntPtr>();
            WinAPI.EnumWindows((wnd, param) =>
            {
                bool relevant = filter(wnd);
                if (relevant)
                    result.Add(wnd);
                bool shouldStop = stop(wnd);
                if (shouldStop)
                    Console.WriteLine("Stop");
                return !shouldStop;
            }, IntPtr.Zero);
            return result;
        }
        public static IEnumerable<IntPtr> GetWindowsByOrder(Func<IntPtr, bool> filter)
        {
            List<IntPtr> skip = new List<IntPtr>();
            List<IntPtr> result = new List<IntPtr>();
            IntPtr desktop = WinAPI.GetDesktopWindow();
            for (IntPtr wnd = WinAPI.GetTopWindow(IntPtr.Zero); wnd != IntPtr.Zero; wnd = WinAPI.GetNextWindow(wnd, WinAPI.GW.GW_HWNDNEXT))
            {
                if (result.Contains(wnd) || skip.Contains(wnd))
                    break;
                else if (filter(wnd))
                    result.Add(wnd);
                else
                    skip.Add(wnd);
            }
            result.Add(desktop);
            return result;
        }
        public static Image GetScreenshot(IntPtr hWnd)
        {
            IntPtr hdcScreen = WinAPI.GetDC(hWnd);
            IntPtr hdc = WinAPI.CreateCompatibleDC(hdcScreen);
            WinAPI.RECT area = new WinAPI.RECT();
            WinAPI.GetWindowRect(hWnd, ref area);
            
            IntPtr hBitmap = WinAPI.CreateCompatibleBitmap(hdcScreen, area.right - area.left, area.bottom - area.top);
            WinAPI.SelectObject(hdc, hBitmap);
            WinAPI.PrintWindow(hWnd, hdc, 0);
            Image resultOpaque = Image.FromHbitmap(hBitmap);
            WinAPI.DeleteObject(hBitmap);
            WinAPI.DeleteDC(hdc);
            IntPtr hRegion = WinAPI.CreateRectRgn(0, 0, 0, 0);
            WinAPI.RegionFlags f = (WinAPI.RegionFlags) WinAPI.GetWindowRgn(hWnd, hRegion);
            Region region = Region.FromHrgn(hRegion);
            WinAPI.DeleteObject(hRegion);
            Bitmap result = new Bitmap(resultOpaque.Width, resultOpaque.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(result);
            g.Clear(Color.Transparent);
            if (f != WinAPI.RegionFlags.ERROR)
                g.SetClip(region, System.Drawing.Drawing2D.CombineMode.Replace);
            if (f != WinAPI.RegionFlags.NULLREGION)
                g.DrawImageUnscaled(resultOpaque, 0, 0);
            g.Dispose();
            region.Dispose();
            resultOpaque.Dispose();
            return result;
        }
    /* And now for the actual code of getting screenshots of windows */
    var windows = ScreenShot.GetWindowsByOrder(this.WindowFilter).Intersect(ScreenShot.GetAllWindows(this.WindowFilter, (wnd) => false)).ToList();
    int index = windows.IndexOf((IntPtr)this.Handle); /* Remove all the windows behind your windows */
    if (index != -1)
        windows.RemoveRange(index, windows.Count - index + 1);
    windows.Reverse();
    /* Get the images of all the windows */
    for (int i = 0; i < windows.Count; ++i )
    {
        var window = windows[i];
        using (var img = ScreenShot.GetScreenshot(window))
        {
            // Get the actual position of the window
            // Draw it's image overlayed on the other windows 9have an accumulating image)
        }
    }
