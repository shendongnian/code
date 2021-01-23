     private static void DrawText(String text, Font font, Color textColor, Color backColor)
    {
        Rectangle displayRectangle; // YOU DECLARE IT HERE OR OUTSIDE THE FUNCTION, but never inside an "if" statement
        Image img = new Bitmap(640, 360);
        Graphics drawing = Graphics.FromImage(img);
        Color color = textColor;
        if (text.Length <= 80)
        {
            displayRectangle = new Rectangle(new Point(20, 100), new Size(img.Width - 1, img.Height - 1));
        }
        else
        {
            displayRectangle = new Rectangle(new Point(20, 80), new Size(img.Width - 1, img.Height - 1));
        }
        StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
        StringFormat format2 = new StringFormat(format1);
        drawing.DrawString(text, font, Brushes.Red, (RectangleF)displayRectangle, format2); //ERROR HERE
        drawing.Dispose();
        string fileName = "f.png";
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        img.Save(path, System.Drawing.Imaging.ImageFormat.Png);
        img.Dispose();
    }
