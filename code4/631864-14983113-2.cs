    Bitmap DrawOutline(Image image, Image outline)
    {
        // Put null checks here.
        Bitmap result = new Bitmap(image);
        using (Graphics graphics = Graphics.FromImage(result))
        {
            Rectangle rect = new Rectangle(0, 0, result.Width, result.Height);
            graphics.DrawImage(outline, rect);
        }
        return result;
    }
    
