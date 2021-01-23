    namespace ConsoleApplication8_Sepia
    {
        using System;
        using System.Drawing;
        using System.Drawing.Imaging;
    
        class Program
        {
            static void Main(string[] args)
            {
                Bitmap b = (Bitmap)Bitmap.FromFile("c:\\temp\\source.jpg");
                SepiaBitmap(b);
                b.Save("c:\\temp\\destination.jpg", ImageFormat.Jpeg);
            }
    
            private static void SepiaBitmap(Bitmap bmp)
            {
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
                IntPtr ptr = bmpData.Scan0;
    
                int numPixels = bmpData.Width * bmp.Height;
                int numBytes = numPixels * 4;
                byte[] rgbValues = new byte[numBytes];
    
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, numBytes);
                for (int i = 0; i < rgbValues.Length; i += 4)
                {
                    int inputRed = rgbValues[i + 2];
                    int inputGreen = rgbValues[i + 1];
                    int inputBlue = rgbValues[i + 0];
    
                    rgbValues[i + 2] = (byte)Math.Min(255, (int)((.393 * inputRed) + (.769 * inputGreen) + (.189 * inputBlue))); //red
                    rgbValues[i + 1] = (byte)Math.Min(255, (int)((.349 * inputRed) + (.686 * inputGreen) + (.168 * inputBlue))); //green
                    rgbValues[i + 0] = (byte)Math.Min(255, (int)((.272 * inputRed) + (.534 * inputGreen) + (.131 * inputBlue))); //blue
                }
    
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, numBytes);
                bmp.UnlockBits(bmpData);
            }
        }
    }
