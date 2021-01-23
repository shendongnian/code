    public static Image GetThumbnailImage(Image OriginalImage, Size ThumbSize)
    {
        Int32 thWidth = ThumbSize.Width;
        Int32 thHeight = ThumbSize.Height;
        Image i = OriginalImage;
        Int32 w = i.Width;
        Int32 h = i.Height;
        Int32 th = thWidth;
        Int32 tw = thWidth;
        if (h > w)
        {
            Double ratio = (Double)w / (Double)h;
            th = thHeight < h ? thHeight : h;
            tw = thWidth < w ? (Int32)(ratio * thWidth) : w;
        }
        else
        {
            Double ratio = (Double)h / (Double)w;
            th = thHeight < h ? (Int32)(ratio * thHeight) : h;
            tw = thWidth < w ? thWidth : w;
        }
        Bitmap target = new Bitmap(tw, th);
        Graphics g = Graphics.FromImage(target);
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.InterpolationMode = InterpolationMode.High;
        Rectangle rect = new Rectangle(0, 0, tw, th);
        g.DrawImage(i, rect, 0, 0, w, h, GraphicsUnit.Pixel);
        return (Image)target;
    }
