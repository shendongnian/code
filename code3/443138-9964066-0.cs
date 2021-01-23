    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    /// <summary>
    /// Summary description for ResizeImage
    /// </summary>
    public class ResizeImage
    {
    public static Image Resize(Image imgToResize, int h, int w)
    {
        Size size = new Size(w, h);
        int sourceWidth = imgToResize.Width;
        int sourceHeight = imgToResize.Height;
        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;
        nPercentW = ((float)size.Width / (float)sourceWidth);
        nPercentH = ((float)size.Height / (float)sourceHeight);
        if (nPercentH < nPercentW)
            nPercent = nPercentH;
        else
            nPercent = nPercentW;
        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);
        Bitmap b = new Bitmap(destWidth, destHeight);
        Graphics g = Graphics.FromImage((Image)b);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
        g.Dispose();
        return (Image)b;
    }
    }
