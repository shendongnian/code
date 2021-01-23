    using (var bmp = new Bitmap(panel1.Width, panel1.Height))
    {
    pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
    bmp.Save("output.png", System.Drawing.Imaging.ImageFormat.Jpeg);
    }
