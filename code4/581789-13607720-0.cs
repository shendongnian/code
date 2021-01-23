    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    static class Program
    {
    
        static void Main()
        {
    
            Bitmap bmp = new Bitmap(100, 100);
    
            using (var bmpData = bmp.SmartLock(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat))
            {
                // use Scan0 etc as normal
            }
        }
    }
    static class BitmapUtils
    {
        public static WrappedBitmapData SmartLock(this Bitmap bitmap, Rectangle rect, ImageLockMode flags, PixelFormat format)
        {
            return new WrappedBitmapData(bitmap, bitmap.LockBits(rect, flags, format));
        }
        public class WrappedBitmapData : IDisposable
        {
            public int Height { get { return data.Height; } }
            public int Width { get { return data.Width; } }
            public IntPtr Scan0 { get { return data.Scan0; } }
            public PixelFormat PixelFormat { get { return data.PixelFormat; } }
            // etc here ^^^ TODO
            internal WrappedBitmapData(Bitmap bmp, BitmapData data)
            {
                this.bmp = bmp;
                this.data = data;
            }
            private Bitmap bmp;
            private BitmapData data;
            public void Dispose()
            {
                if (data != null && bmp != null)
                {
                    bmp.UnlockBits(data);
                }
                data = null;
                bmp = null;
            }
        }
    
    }
