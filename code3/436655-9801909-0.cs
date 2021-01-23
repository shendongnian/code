    var allCode = "...copy all of the code into here";
    var font = new Font("Arial", 13);
    SizeF size;
    using (var g = Graphics.FromImage(new Bitmap(1, 1)))
    {
        size = g.MeasureString(allCode, font);
    }
    var bitmap = new Bitmap((int)size.Width + 20, (int)size.Height + 20);
    using (var g = Graphics.FromImage(bitmap))
    {
        g.DrawString(allCode, font, Brushes.Black, 10, 10);
    }
    bitmap.Save("code.bmp");
