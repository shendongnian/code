    int w = 640;
    int h = 480;
    System.Drawing.Color c = System.Drawing.Color.White;
    string imagePath = Server.MapPath("~/image/1.jpg"); // here you would get the image source of your Image control
    Image img = Image.FromFile(imagePath);
    System.Drawing.Bitmap bt = new System.Drawing.Bitmap(w, h);
    System.Drawing.Graphics oGraphics = System.Drawing.Graphics.FromImage(bt);
    System.Drawing.Brush brush = new System.Drawing.SolidBrush(c);
    oGraphics.FillRectangle(brush, 0, 0, w, h);
    oGraphics.DrawImage(img, 0, 0, img.Width, img.Height);
    oGraphics.DrawString("this is some text", new Font("Arial", 12, FontStyle.Italic), SystemBrushes.WindowText, new PointF(50, 50));
    bt.Save("c:\\image10.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
