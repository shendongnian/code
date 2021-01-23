    using (Bitmap b = new Bitmap(50, 50)) {
      using (Graphics g = Graphics.FromImage(b)) {
        g.Clear(Color.Green);
     }
      b.Save(@"C:\green.png", ImageFormat.Png);
    }
