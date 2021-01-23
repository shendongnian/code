    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    namespace ImageCloneTest
    {
        static class Program
        {
            [DllImport("kernel32", EntryPoint = "RtlMoveMemory")]
            public unsafe static extern void CopyMemory(byte* Destination, byte* Source, int Length);
            [DllImport("kernel32", EntryPoint = "RtlMoveMemory")]
            public static extern void CopyMemory(IntPtr Destination, IntPtr Source, int Length);
            public static Bitmap Clone(Bitmap SourceBitmap, PixelFormat Format)
            {
                // copy image if pixel format is the same
                if (SourceBitmap.PixelFormat == Format) return Clone(SourceBitmap);
                int width = SourceBitmap.Width;
                int height = SourceBitmap.Height;
                // create new image with desired pixel format
                Bitmap bitmap = new Bitmap(width, height, Format);
                // draw source image on the new one using Graphics
                Graphics g = Graphics.FromImage(bitmap);
                //fill background in case orig bitmap contains transparent regions.
                g.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
                g.DrawImage(SourceBitmap, 0, 0, width, height);
                g.Dispose();
                return bitmap;
            }
            // and with unspecified PixelFormat it works strange too
            public static Bitmap Clone(Bitmap SourceBitmap)
            {
                // get source image size
                int width = SourceBitmap.Width;
                int height = SourceBitmap.Height;
                Rectangle rect = new Rectangle(0, 0, width, height);
                // lock source bitmap data
                BitmapData srcData = SourceBitmap.LockBits(rect, ImageLockMode.ReadOnly, SourceBitmap.PixelFormat);
                // create new image
                Bitmap dstBitmap = new Bitmap(width, height, SourceBitmap.PixelFormat);
                // lock destination bitmap data
                BitmapData dstData = dstBitmap.LockBits(rect, ImageLockMode.WriteOnly, dstBitmap.PixelFormat);
                CopyMemory(dstData.Scan0, srcData.Scan0, height * srcData.Stride);
                // unlock both images
                dstBitmap.UnlockBits(dstData);
                SourceBitmap.UnlockBits(srcData);
                // copy pallete
                if (BitmapHasPalette(SourceBitmap) && BitmapHasPalette(dstBitmap))
                {
                    ColorPalette srcPalette = SourceBitmap.Palette;
                    ColorPalette dstPalette = dstBitmap.Palette;
                    int n = srcPalette.Entries.Length;
                    for (int i = 0; i < n; i++)
                    {
                        dstPalette.Entries[i] = srcPalette.Entries[i];
                    }
                    dstBitmap.Palette = dstPalette;
                }
                return dstBitmap;
            }
            public static bool BitmapHasPalette(Bitmap SourceBitmap)
            {
                if (SourceBitmap == null) return false;
                switch (SourceBitmap.PixelFormat)
                {
                    case PixelFormat.Format1bppIndexed:
                    case PixelFormat.Format4bppIndexed:
                    case PixelFormat.Format8bppIndexed:
                    case PixelFormat.Indexed:
                        return true;
                }
                return false;
            }
        }
    }
