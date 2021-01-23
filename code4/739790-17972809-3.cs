    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows;
    using System.Windows.Interop;
    using System.Runtime.InteropServices;
    using System.Drawing.Drawing2D;
    
    namespace WpfApplication1
    {
        class FastCanvas : Canvas
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr CreateFileMapping(IntPtr hFile,
                                                           IntPtr lpFileMappingAttributes,
                                                           uint flProtect,
                                                           uint dwMaximumSizeHigh,
                                                           uint dwMaximumSizeLow,
                                                           string lpName);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject,
                                                       uint dwDesiredAccess,
                                                       uint dwFileOffsetHigh,
                                                       uint dwFileOffsetLow,
                                                       uint dwNumberOfBytesToMap);
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool UnmapViewOfFile(IntPtr lbBaseAddress);
    
    
            protected System.Drawing.Graphics GDIGraphics;
            protected InteropBitmap interopBitmap = null;
            protected InteropBitmap buffBitmap = null;
    
            private const uint FILE_MAP_ALL_ACCESS = 0xF001F;
            private const uint PAGE_READWRITE = 0x04;
    
            private int bpp = PixelFormats.Bgra32.BitsPerPixel / 8;
            protected IntPtr MapViewPointer;
    
            public struct ScopeLine
            {
                public SolidColorBrush lineBrush;
                public List<Point> linePoints;
            }
    
            public List<ScopeLine> Lines = new List<ScopeLine>();
    
            protected override void OnRender(DrawingContext dc)
            {
                base.OnRender(dc);
                if (Lines.Count() > 0)
                {              
                        ImageSource drIs = null;
    
                        if (interopBitmap == null)
                        {
                            uint byteCount = (uint)((int)this.ActualWidth * (int)this.ActualHeight * bpp);
    
                            var fileMappingPointer = CreateFileMapping(new IntPtr(-1), IntPtr.Zero, PAGE_READWRITE, 0, byteCount, null);
                            this.MapViewPointer = MapViewOfFile(fileMappingPointer, FILE_MAP_ALL_ACCESS, 0, 0, byteCount);
                            PixelFormat format = PixelFormats.Bgra32;
                            var stride = (int)((int)this.ActualWidth * format.BitsPerPixel / 8);
                            this.interopBitmap = Imaging.CreateBitmapSourceFromMemorySection(fileMappingPointer,
                                                                                             (int)this.ActualWidth,
                                                                                             (int)this.ActualHeight,
                                                                                             format,
                                                                                             stride,
                                                                                             0) as InteropBitmap;
    
                            this.GDIGraphics = GetGdiGraphics(MapViewPointer);
                        }
    
                        GDIGraphics.FillRectangle(System.Drawing.Brushes.Transparent,
                                                        new System.Drawing.Rectangle(0, 0,
                                                        (int)this.ActualWidth,
                                                        (int)this.ActualHeight));
    
                        foreach (ScopeLine dLine in Lines)
                        {
                            var pointCount = dLine.linePoints.Count();
                            Color lpColour;
                            lpColour = dLine.lineBrush.Color;
                            System.Drawing.Color lp2Colour;
                            lp2Colour = System.Drawing.Color.FromArgb(lpColour.A,
                                                                      lpColour.R,
                                                                      lpColour.G,
                                                                      lpColour.B);
    
    
                            System.Drawing.Pen lpPen = new System.Drawing.Pen(lp2Colour, 1.5f);
                            System.Drawing.PointF newPoint = new System.Drawing.PointF((float)dLine.linePoints[0].X,
                                                                                       (float)dLine.linePoints[0].Y);
    
    
                            for (int i = 0; i < pointCount - 1; i++)
                            {
                                System.Drawing.PointF newPoint1 = new System.Drawing.PointF((float)dLine.linePoints[i + 1].X,
                                                                                                (float)dLine.linePoints[i + 1].Y);
                                GDIGraphics.DrawLine(lpPen, newPoint, newPoint1);
                                newPoint = newPoint1;
                            }
    
                        }
    
                        var bmpsrc = interopBitmap.GetAsFrozen();
                        if (bmpsrc == null || bmpsrc.CheckAccess())
                        {
                            drIs = (System.Windows.Media.Imaging.BitmapSource)bmpsrc;
                        }
                        else
                        {
                            //Debug.WriteLine("No access to TheImage");
                        }                                    
    
                        dc.DrawImage(drIs, new Rect(this.RenderSize));
                }
            }
    
            private System.Drawing.Graphics GetGdiGraphics(IntPtr mapViewPointer)
            {
                System.Drawing.Graphics gdiGraphics;
                System.Drawing.Bitmap gdiBitmap;
                gdiBitmap = new System.Drawing.Bitmap((int)this.ActualWidth,
                                                      (int)this.ActualHeight,
                                                      (int)this.ActualWidth * bpp,
                                                      System.Drawing.Imaging.PixelFormat.Format32bppArgb,
                                                      mapViewPointer);
    
                gdiGraphics = System.Drawing.Graphics.FromImage(gdiBitmap);
                gdiGraphics.CompositingMode = CompositingMode.SourceCopy;
                gdiGraphics.CompositingQuality = CompositingQuality.HighSpeed;
                gdiGraphics.SmoothingMode = SmoothingMode.HighSpeed;
    
                return gdiGraphics;
            }
        }
    }
