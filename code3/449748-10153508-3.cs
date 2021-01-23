    private void PlotSignal(PointF[] signal, PictureBox pictureBox)
    {
      Bitmap bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
      signal = ScaleSignal(signal, bmp.Width, bmp.Height); // Scale signal to fit image
      using(Graphics gfx = Graphics.FromImage(bmp))
      {
        gfx.SmoothingMode = SmoothingMode.HighQuality;
        gfx.TranslateTransform(0, bmp.Height / 2); // Move Y=0 to center of image
        gfx.ScaleTransform(1, -1); // Make positive Y axis point upward
        gfx.DrawLine(Pens.Black, 0, 0, bmp.Width, 0); // Draw zero axis
        gfx.DrawLines(Pens.Blue, signal); // Draw signal
      }
      // Make sure the bitmap is disposed the next time around
      Image old = pictureBox.Image;
      pictureBox.Image = bmp;
      if(old != null)
        old.Dispose();
    }
