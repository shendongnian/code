    public static Bitmap RotateImg(Bitmap bmp, float angle, Color bkColor)
    {
        angle = angle % 360;
        if (angle > 180)
            angle -= 360;
        System.Drawing.Imaging.PixelFormat pf = default(System.Drawing.Imaging.PixelFormat);
        if (bkColor == Color.Transparent)
        {
            pf = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
        }
        else
        {
            pf = bmp.PixelFormat;
        }
	
        float sin = (float)Math.Abs(Math.Sin(angle * Math.PI / 180.0)); // this function takes radians
        float cos = (float)Math.Abs(Math.Cos(angle * Math.PI / 180.0)); // this one too
        float newImgWidth = sin * bmp.Height + cos * bmp.Width;
        float newImgHeight = sin * bmp.Width + cos * bmp.Height;
        float originX = 0f;
        float originY = 0f;
	
        if (angle > 0)
        {
            if (angle <= 90)
                originX = sin * bmp.Height;
            else
            {
                originX = newImgWidth;
                originY = newImgHeight - sin * bmp.Width;
            }
        }
        else
        {
            if (angle >= -90)
            originY = sin * bmp.Width;
            else
            {
                originX = newImgWidth - sin * bmp.Height;
                originY = newImgHeight;
            }
        }
	
        Bitmap newImg = new Bitmap((int)newImgWidth, (int)newImgHeight, pf);
        Graphics g = Graphics.FromImage(newImg);
        g.Clear(bkColor);
        g.TranslateTransform(originX, originY); // offset the origin to our calculated values
        g.RotateTransform(angle); // set up rotate
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
        g.DrawImageUnscaled(bmp, 0, 0); // draw the image at 0, 0
        g.Dispose();
		
        return newImg;
    }
