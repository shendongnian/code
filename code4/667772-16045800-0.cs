    Image image = Image.FromFile("cloud.png");
    Bitmap bmp = new Bitmap(image.Width, image.Height);
    using (Graphics g = Graphics.FromImage(bmp)) {
      g.Clear(Color.SkyBlue);
      g.InterpolationMode = InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = PixelOffsetMode.None;
      g.DrawImage(image, Point.Empty);
    }
