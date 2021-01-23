    public class SingleLayeredForm : Form
    {
        public new event PaintEventHandler Paint;
        public SingleLayeredForm()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.Manual;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                if (DesignMode) return base.CreateParams;
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle = createParams.ExStyle | 0x80000;
                return createParams;
            }
        }
        public void SetBitmap(Bitmap bitmap)
        {
            if (!IsHandleCreated || DesignMode) return;
            IntPtr oldBits = IntPtr.Zero;
            IntPtr screenDC = WinAPI.GetDC(IntPtr.Zero);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr memDC = WinAPI.CreateCompatibleDC(screenDC);
            try
            {
                Point topLocation = new Point(this.Left, this.Top);
                Size bitmapSize = new Size(bitmap.Width, bitmap.Height);
                WinAPI.BLENDFUNCTION blendFunc = new WinAPI.BLENDFUNCTION();
                Point sourceLocation = Point.Empty;
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                oldBits = WinAPI.SelectObject(memDC, hBitmap);
                blendFunc.BlendOp = WinAPI.AC_SRC_OVER;
                blendFunc.SourceConstantAlpha = 255;
                blendFunc.AlphaFormat = WinAPI.AC_SRC_ALPHA;
                blendFunc.BlendFlags = 0;
                WinAPI.UpdateLayeredWindow(Handle, screenDC, ref topLocation, ref bitmapSize, memDC, ref sourceLocation, 0, ref blendFunc, WinAPI.ULW_ALPHA);
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    WinAPI.SelectObject(memDC, oldBits);
                    WinAPI.DeleteObject(hBitmap);
                }
                WinAPI.ReleaseDC(IntPtr.Zero, screenDC);
                WinAPI.DeleteDC(memDC);
            }
        }
        public new void Invalidate()
        {
            using (Bitmap bitmap = new Bitmap(this.ClientSize.Width, this.ClientSize.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    if (this.Paint != null)
                        this.Paint(this, new PaintEventArgs(graphics, Rectangle.Empty));
                }
                SetBitmap(bitmap);
            }
        }
    }
    public sealed class WinAPI
    {
        [DllImport("user32.dll")]
        public static extern bool HideCaret(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true, SetLastError = true)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [DllImport("user32.dll")]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, uint crKey, [In] ref BLENDFUNCTION pblend, uint dwFlags);
        
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr ptr);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);
        
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);
        public const byte AC_SRC_OVER = 0;
        public const byte AC_SRC_ALPHA = 1;
        public const byte ULW_ALPHA = 2;
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
