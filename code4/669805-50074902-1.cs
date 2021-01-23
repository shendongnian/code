    // Created by: Motaz Alnuweiri
    
    // Reference:
    // URL1: https://www.autoitscript.com/forum/topic/181956-drawthemebackground-bitmap-alpha/
    // URL2: https://gist.github.com/wavescholar/11297223#file-gdi-bitmap-conversion-L71
    // URL3: https://www.experts-exchange.com/questions/20872978/BITMAPINFOHEADER-from-NET-Bitmap.html
    
    
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    
    public class Helper
    {
        #region Win32 Native APIs
        internal class NativeMethods
        {
            // CreateDIBSection funcation iUsage value
            internal const int DIB_RGB_COLORS = 0x00;
            internal const int DIB_PAL_COLORS = 0x01;
            internal const int DIB_PAL_INDICES = 0x02;
    
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            internal static extern bool DeleteObject(IntPtr hObject);
    
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            internal static extern int InvalidateRect(IntPtr hwnd, IntPtr rect, int bErase);
    
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            internal static extern IntPtr GetDC(IntPtr hwnd);
    
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            internal static extern IntPtr CreateCompatibleDC(IntPtr hdc);
    
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            internal static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);
    
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            internal static extern int DeleteDC(IntPtr hdc);
    
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
    
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            internal static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO bmi, uint iUsage,
                out IntPtr bits, IntPtr hSection, uint dwOffset);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            internal static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
    
            [StructLayout(LayoutKind.Sequential)]
            internal struct BITMAPINFO
            {
                public Int32 biSize;
                public Int32 biWidth;
                public Int32 biHeight;
                public Int16 biPlanes;
                public Int16 biBitCount;
                public Int32 biCompression;
                public Int32 biSizeImage;
                public Int32 biXPelsPerMeter;
                public Int32 biYPelsPerMeter;
                public Int32 biClrUsed;
                public Int32 biClrImportant;
            }
        }
        #endregion
    
        public static Image VisualStyleRendererToImage(VisualStyleElement element, Rectangle bounds)
        {
            if (ToolStripManager.VisualStylesEnabled && VisualStyleRenderer.IsElementDefined(element))
            {
                VisualStyleRenderer renderer = new VisualStyleRenderer(element);
    
                using (Bitmap bit = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb))
                {
                    NativeMethods.BITMAPINFO bmi = new NativeMethods.BITMAPINFO();
    
                    bmi.biWidth = bit.Width;
                    bmi.biHeight = bit.Height;
                    bmi.biPlanes = 1;
                    bmi.biBitCount = 32;
                    bmi.biXPelsPerMeter = (int)bit.HorizontalResolution;
                    bmi.biYPelsPerMeter = (int)bit.VerticalResolution;
                    bmi.biSize = Marshal.SizeOf(typeof(NativeMethods.BITMAPINFO));
    
                    IntPtr bits;
                    IntPtr bmp = NativeMethods.CreateDIBSection(IntPtr.Zero, ref bmi,
                        NativeMethods.DIB_RGB_COLORS, out bits, IntPtr.Zero, 0);
    
                    IntPtr dc = NativeMethods.GetDC(IntPtr.Zero);
                    IntPtr hdc = NativeMethods.CreateCompatibleDC(dc);
                    NativeMethods.SelectObject(hdc, bmp);
    
                    using (Graphics g = Graphics.FromHdc(hdc))
                    {
                        renderer.DrawBackground(g, bounds);
                    }
    
                    Bitmap image = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
    
                    using (Bitmap tempImage = new Bitmap(bounds.Width, bounds.Height, bounds.Width * 4,
                        PixelFormat.Format32bppArgb, bits))
                    {
                        BitmapData tempBitmapData = tempImage.LockBits(bounds, ImageLockMode.ReadOnly,
                            PixelFormat.Format32bppArgb);
                        BitmapData bitmapData = image.LockBits(bounds, ImageLockMode.WriteOnly,
                            PixelFormat.Format32bppArgb);
    
                        NativeMethods.CopyMemory(bitmapData.Scan0, tempBitmapData.Scan0,
                            (uint)tempBitmapData.Stride * (uint)tempBitmapData.Height);
    
                        tempImage.UnlockBits(tempBitmapData);
                        image.UnlockBits(bitmapData);
                    }
    
                    NativeMethods.DeleteObject(bmp);
                    NativeMethods.DeleteDC(hdc);
                    NativeMethods.ReleaseDC(IntPtr.Zero, dc);
    
                    return image;
                }
            }
            else
            {
                return new Bitmap(bounds.Width, bounds.Height);
            }
        }
    }
