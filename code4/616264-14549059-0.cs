    Bitmap img = new Bitmap(300, 50);
    Graphics g = Graphics.FromImage(img);
    g.FillRectangle(Brushes.White, 1, 1, 298, 48);
    // render the image to output stream
    img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
    //clean up
    g.Dispose();
    img.Dispose();
