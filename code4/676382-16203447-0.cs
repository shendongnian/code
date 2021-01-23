    Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
    Rectangle rect = new Rectangle(0, 0, panel1.Width, panel1.Height);
    panel1.DrawToBitmap(bmp, rect);
    Clipboard.SetImage(bmp);
    richTextBox1.Paste();
