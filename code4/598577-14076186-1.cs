    Rectangle displayRectangle;
    if (text.Length <= 80)
    {
        displayRectangle = new Rectangle(new Point(20, 100), new Size(img.Width - 1, img.Height - 1));
    }
    else
    {
        displayRectangle = new Rectangle(new Point(20, 80), new Size(img.Width - 1, img.Height - 1));
    }
