        private const int SRCCOPY = 0xCC0020;
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern int BitBlt(
          IntPtr hdcDest,     // handle to destination DC (device context)
          int nXDest,         // x-coord of destination upper-left corner
          int nYDest,         // y-coord of destination upper-left corner
          int nWidth,         // width of destination rectangle
          int nHeight,        // height of destination rectangle
          IntPtr hdcSrc,      // handle to source DC
          int nXSrc,          // x-coordinate of source upper-left corner
          int nYSrc,          // y-coordinate of source upper-left corner
          int dwRop  // raster operation code
          );
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr obj);
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        public static extern void DeleteObject(IntPtr obj);
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap sourceBitmap = new Bitmap(64, 64, PixelFormat.Format32bppRgb);
            Graphics sourceGraphics = Graphics.FromImage(sourceBitmap);
            Bitmap destBitmap = new Bitmap(64, 64, PixelFormat.Format32bppRgb);
            Graphics destGraphics = Graphics.FromImage(destBitmap);
            sourceGraphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(0, 0, 30, 30));
            sourceGraphics.FillRectangle(new SolidBrush(Color.Green), new Rectangle(30, 30, 30, 30));
            destGraphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0, 0, 30, 30));
            destGraphics.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(30, 30, 30, 30));
            IntPtr destDC = destGraphics.GetHdc();
            IntPtr destCDC = CreateCompatibleDC(destDC);
            IntPtr destHB = destBitmap.GetHbitmap();
            IntPtr oldDest = SelectObject(destCDC, destHB);
            IntPtr sourceDC = sourceGraphics.GetHdc();
            IntPtr sourceCDC = CreateCompatibleDC(sourceDC);
            IntPtr sourceHB = sourceBitmap.GetHbitmap();
            IntPtr oldSource = SelectObject(sourceCDC, sourceHB);
            int success = BitBlt(
                destDC, 0, 0, 64, 64, sourceCDC, 0, 0, SRCCOPY
            );
            SelectObject(destCDC, oldDest);
            SelectObject(sourceCDC, oldSource);
            DeleteObject(destCDC);
            DeleteObject(sourceCDC);
            DeleteObject(destHB);
            DeleteObject(sourceHB);
            destGraphics.ReleaseHdc();
            sourceGraphics.ReleaseHdc();
            pictureBox1.Image = sourceBitmap;
            pictureBox2.Image = destBitmap;
        }
