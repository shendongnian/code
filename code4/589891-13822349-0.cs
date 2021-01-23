    using System;
    using System.Collections.Generic;
    using System.Text;
    
    using System.Drawing;
    using System.Drawing.Imaging;
    using log4net;
    
    namespace ImageDiff
    {
        public class ImageDifferences
        {
            private static ILog mLog = LogManager.GetLogger("ImageDifferences");
    
            public static unsafe Bitmap PixelDiff(Image a, Image b)
            {
                if (!a.Size.Equals(b.Size)) return null;
                if (!(a is Bitmap) || !(b is Bitmap)) return null;
    
                return PixelDiff(a as Bitmap, b as Bitmap);
            }
    
            public static unsafe Bitmap PixelDiff(Bitmap a, Bitmap b)
            {
                Bitmap output = new Bitmap(
                    Math.Max(a.Width, b.Width),
                    Math.Max(a.Height, b.Height),
                    PixelFormat.Format32bppArgb);
    
                Rectangle recta = new Rectangle(Point.Empty, a.Size);
                Rectangle rectb = new Rectangle(Point.Empty, b.Size);
                Rectangle rectOutput = new Rectangle(Point.Empty, output.Size);
    
                BitmapData aData = a.LockBits(recta, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData bData = b.LockBits(rectb, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData outputData = output.LockBits(rectOutput, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
    
                try
                {
                    byte* aPtr = (byte*)aData.Scan0;
                    byte* bPtr = (byte*)bData.Scan0;
                    byte* outputPtr = (byte*)outputData.Scan0;
                    int len = aData.Stride * aData.Height;
    
                    for (int i = 0; i < len; i++)
                    {
                        // For alpha use the average of both images (otherwise pixels with the same alpha won't be visible)
                        if ((i + 1) % 4 == 0)
                            *outputPtr = (byte)((*aPtr + *bPtr) / 2);
                        else
                            *outputPtr = (byte)~(*aPtr ^ *bPtr);
    
                        outputPtr++;
                        aPtr++;
                        bPtr++;
                    }
    
                    return output;
                }
                catch (Exception ex)
                {
                    mLog.Error("Error calculating image differences: " + ex.Message);
                    return null;
                }
                finally
                {
                    a.UnlockBits(aData);
                    b.UnlockBits(bData);
                    output.UnlockBits(outputData);
                }
            }
        }
    }
