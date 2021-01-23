    Bitmap DrawCardWithOutline(Image card, Image outline)
    {
        /// Put null checks here.
        Bitmap result = new Bitmap(outline.Width, outline.Height);
        using (Graphics graphics = Graphics.FromImage(result))
        {
            Rectangle cardRect = new Rectangle(0, 0, result.Width, result.Height);
            graphics.DrawImage(card, cardRect);
            Rectangle outlineRect = new Rectangle(0, 0, result.Width, result.Height);
            graphics.DrawImage(outline, outlineRect);
        }
        return result;
    }
