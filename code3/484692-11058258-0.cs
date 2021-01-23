    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    namespace Helpers
    {
        public static class ImageUtilities
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            public static Dictionary<String, ImageSource> _cachedImages = new Dictionary<string, ImageSource>();
    
            public static ImageSource ImageSourceFromBitmap(Bitmap bitmap)
            {
                if (bitmap == null)
                {
                    return ImageSourceFromResourceKey(Properties.Resources.Exit, "Exit");
                }
                
                try
                {
                    IntPtr hBitmap = bitmap.GetHbitmap();
                    BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                        hBitmap,
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
    
                    DeleteObject(hBitmap);
                    return bitmapSource;
                }
                catch (Exception ex)
                {
                    //Error loading image.. Just log it...
                    Helpers.Debug(ex.ToString());
                }
    
                return null;
            }
    
            public static ImageSource ImageSourceFromResourceKey(Bitmap bitmap, string imageKey)
            {
                if (!_cachedImages.ContainsKey(imageKey))
                {
                    _cachedImages[imageKey] = ImageSourceFromBitmap(bitmap);
                }
    
                return _cachedImages[imageKey];
            }
        }
    }
