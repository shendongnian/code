    public static class BitmapExtensions
    {
        public static Bitmap ChangeColor(this Bitmap image, Color fromColor, Color toColor)
        {
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetRemapTable(new ColorMap[]
            {
                new ColorMap()
                {
                    OldColor = fromColor,
                    NewColor = toColor,
                }
            }, ColorAdjustType.Bitmap);
    
            using (Graphics g = Graphics.FromImage(image))
            {
                g.DrawImage(
                    image,
                    new Rectangle(Point.Empty, image.Size),
                    0, 0, image.Width, image.Height,
                    GraphicsUnit.Pixel,
                    attributes);
            }
    
            return image;
        }
    }
