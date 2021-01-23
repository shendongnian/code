    Rectangle displayRectangle; //declaration
    if (text.Length <= 80)
    {
      //setting
      displayRectangle = new Rectangle(new Point(20, 100), new Size(img.Width - 1, img.Height - 1));
    }
    else
    {
      //setting
      displayRectangle = new Rectangle(new Point(20, 80), new Size(img.Width - 1, img.Height - 1));
    }
    ....
    //usage
    drawing.DrawString(text, font, Brushes.Red, (RectangleF)displayRectangle, format2);
