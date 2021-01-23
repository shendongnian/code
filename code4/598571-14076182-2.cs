    Rectangle displayRectangle=null;
    
    if (text.Length <= 80)
    {
        displayRectangle = new Rectangle(new Point(20, 100), new Size(img.Width  img.Height - 1));
    }
    else
    {
        displayRectangle = new Rectangle(new Point(20, 80), new Size(img.Width -  img.Height - 1));
    }
