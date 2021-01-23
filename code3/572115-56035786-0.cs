    private static Bitmap DrawBitmapWithBorder(Bitmap bmp, int borderSize = 10)
    {
        int newWidth = bmp.Width + (borderSize * 2);
        int newHeight = bmp.Height + (borderSize * 2);
        Image newImage = new Bitmap(newWidth, newHeight);
        using (Graphics gfx = Graphics.FromImage(newImage))
        {
            using (Brush border = new SolidBrush(Color.White))
            {
                gfx.FillRectangle(border, 0, 0,
                    newWidth, newHeight);
            }
            gfx.DrawImage(bmp, new Rectangle(borderSize, borderSize, bmp.Width, bmp.Height));
        }
        return (Bitmap)newImage;
    }
