    public static class Emfutilities
    {
            public static BitmapSource ToBitmapSource(string path)
            {
                using (System.Drawing.Imaging.Metafile emf = new System.Drawing.Imaging.Metafile(path))
                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(emf.Width, emf.Height))
                {
                    bmp.SetResolution(emf.HorizontalResolution, emf.VerticalResolution);
                    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp))
                    {
                        g.DrawImage(emf, 0, 0);
                        return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    }
                }
            }
    }
