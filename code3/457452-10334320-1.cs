    private static unsafe bool IsGrayScale(Image image)
    {
        using (var bmp = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb))
        {
            using (var g = Graphics.FromImage(bmp))
            {
                g.DrawImage(image, 0, 0);
            }
            var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
            
            var pt = (int*)data.Scan0;
            var res = true;
            for (var i = 0; i < data.Height * data.Width; i++)
            {
                var color = Color.FromArgb(pt[i]);
                if (color.A != 0 && (color.R != color.G || color.G != color.B))
                {
                    res = false;
                    break;
                }
            }
            bmp.UnlockBits(data);
            return res;
        }
    }
