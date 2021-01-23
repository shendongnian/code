    Image imageBackground = Image.FromFile("bitmap1.png");
    Image imageOverlay = Image.FromFile("bitmap2.png");
    
    Image img = new Bitmap(imageBackground.Width, imageBackground.Height);
    using (Graphics gr = Graphics.FromImage(img))
    {
        gr.DrawImage(imageBackground, new Point(0, 0));
        gr.DrawImage(imageOverlay, new Point(0, 0));
    }
    img.Save("output.png", ImageFormat.Png);
