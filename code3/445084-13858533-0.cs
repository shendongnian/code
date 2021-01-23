    using System.Drawing;
    using System.Drawing.Imaging;
    foreach (var arg in args)
        {
            Image gif = Image.FromFile(arg);
            FrameDimension dim = new FrameDimension(gif.FrameDimensionsList[0]);
            int frames = gif.GetFrameCount(dim);
            Bitmap resultingImage = new Bitmap(gif.Width * frames, gif.Height);
            for (int i = 0; i < frames; i++)
            {
                gif.SelectActiveFrame(dim, i);
                Rectangle destRegion = new Rectangle(gif.Width * i, 0, gif.Width, gif.Height);
                Rectangle srcRegion = new Rectangle(0, 0, gif.Width, gif.Height);
                using (Graphics grD = Graphics.FromImage(resultingImage))
                {
                    grD.DrawImage(gif, destRegion, srcRegion, GraphicsUnit.Pixel);
                }
            }
            resultingImage.Save("res.png", ImageFormat.Png);
        }
