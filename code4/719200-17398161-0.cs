    public static Image ResizeCanvas(Image original, Size newSize, Color background)
        {
            int xStart = (newSize.Width / 2) - (original.Width / 2);
            int yStart = (newSize.Height / 2) - (original.Height / 2);
            // Create blank canvas
            Bitmap resizedImg = new Bitmap(newSize.Width, newSize.Height);
            Graphics gfx = Graphics.FromImage(resizedImg);
            // Fill canvas
            gfx.FillRectangle(new SolidBrush(background), new Rectangle(new Point(0, 0), newSize));
            gfx.DrawImage(original, xStart, yStart, original.Width, original.Height);
            return resizedImg;
        }
