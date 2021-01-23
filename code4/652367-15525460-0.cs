    var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
    
    using (var graphics = Graphics.FromImage(bmp))
    {
        // ...
        graphics.DrawImage(...);
        // ...
    }
    
    bmp.Save("c:\\test.png", ImageFormat.Png);
