    button1.ForeColor = Color.White;
    Bitmap bmp = new Bitmap(button1.Width, button1.Height);
    using (Graphics g = Graphics.FromImage(bmp)) {
      Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
      using (LinearGradientBrush br = new LinearGradientBrush(
                                          r,
                                          Color.Red,
                                          Color.DarkRed,
                                          LinearGradientMode.Vertical)) {
          g.FillRectangle(br, r);
        }
      }
