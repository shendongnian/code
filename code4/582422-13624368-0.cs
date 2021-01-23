    public class ZoomPanWindow
    {
        private Bitmap map;
        private Graphics bmpGfx;
        private IntPtr hBitmap;
        public Bitmap Map
        {
            get { return map; }
            set 
            {
                if (map != value)
                {
                    map = value;
                    //dispose/delete any previous caches
                    if (bmpGfx != null) bmpGfx.Dispose();
                    if (hBitmap != null) StretchBltHelper.DeleteObject(hBitmap);
                    if (value == null) return;
                    //cache the new HBitmap and Graphics.
                    bmpGfx = Graphics.FromImage(map);
                    hBitmap = map.GetHbitmap();
                 }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (map == null) return;
            //finally, the actual painting!
            Rectangle mapRect = //whatever zoom/pan logic you implemented.
            Rectangle thisRect = new Rectangle(0, 0, this.Width, this.Height);
            StretchBltHelper.DrawStretch(
                hBitmap,
                bmpGfx,
                e.Graphics,
                mapRect,
                thisRect);
        }
    }
    public static class StretchBltHelper
    {
        public static void DrawStretch(IntPtr hBitmap, Graphics srcGfx, Graphics destGfx,
            Rectangle srcRect, Rectangle destRect)
        {
            IntPtr pTarget = destGfx.GetHdc();
            IntPtr pSource = CreateCompatibleDC(pTarget);
            IntPtr pOrig = SelectObject(pSource, hBitmap);
            if (!StretchBlt(pTarget, destRect.X, destRect.Y, destRect.Width, destRect.Height,
                pSource, srcRect.X, srcRect.Y, srcRect.Width, srcRect.Height,
                TernaryRasterOperations.SRCCOPY))
            throw new Win32Exception(Marshal.GetLastWin32Error());
            IntPtr pNew = SelectObject(pSource, pOrig);
            DeleteDC(pSource);
            destGfx.ReleaseHdc(pTarget);
        }
        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern System.IntPtr SelectObject(
            [In()] System.IntPtr hdc,
            [In()] System.IntPtr h);
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        static extern bool DeleteDC(IntPtr hdc);
 
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(
            [In()] System.IntPtr ho);
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest,
            int nWidthDest, int nHeightDest,
            IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
            TernaryRasterOperations dwRop);
        public enum TernaryRasterOperations : uint
        {
            SRCCOPY = 0x00CC0020
     	    //there are many others but we don't need them for this purpose, omitted for brevity
        }
    }
