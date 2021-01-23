    private Region InvertRegion(Region region, int width, int height)
    {
        Bitmap mask = new Bitmap(width, height);
        Graphics.FromImage(mask).FillRegion(Brushes.Black, region);
        int matchColor = Color.Black.ToArgb();
        Region inverted = new System.Drawing.Region();
        inverted.MakeEmpty();
        Rectangle rc = new Rectangle(0, 0, 0, 0);
        bool inimage = false;
        for (int y = 0; y < mask.Height; y++)
        {
            for (int x = 0; x < mask.Width; x++)
            {
                if (!inimage)
                {
                    if (mask.GetPixel(x, y).ToArgb() != matchColor)
                    {
                        inimage = true;
                        rc.X = x;
                        rc.Y = y;
                        rc.Height = 1;
                    }
                }
                else
                {
                    if (mask.GetPixel(x, y).ToArgb()  == matchColor)
                    {
                        inimage = false;
                        rc.Width = x - rc.X;
                        inverted.Union(rc);
                    }
                }
            }
            if (inimage)
            {
                inimage = false;
                rc.Width = mask.Width - rc.X;
                inverted.Union(rc);
            }
        }
        return inverted;
    }
