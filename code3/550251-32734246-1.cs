    public Image addSubtitleToImage(string path, int height, string title)
    {
        Bitmap image = new Bitmap(path);
        Bitmap newImage = new Bitmap(image.Width, image.Height + height);
        using (Graphics g = Graphics.FromImage(newImage))
        {
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0,   newImage.Width, newImage.Height));
            g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
            Font font = new Font("Tahoma", 30.0f);
            g.DrawString(title, font, Brushes.White, new PointF(image.Width/2 , image.Height+));
                
        }
        return newImage;
    }
