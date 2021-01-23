    private void timer1_Tick(object sender, EventArgs e) {
      if (!breakCheck) {
        using (Pen p = new Pen(Color.FromArgb(alpha, 255, 255, 255), image.Width)) {
          using (Graphics g = Graphics.FromImage(image)) {
            g.DrawRectangle(p, 0, 0, image.Width, image.Height);
          }
        }
        if (backButtonClick) {
          alpha--;
          if (alpha == 0) {
            timer1.Stop();
          }
        } else {
          alpha++;
          if (alpha == MAX) {
            timer1.Stop();
          }
        }
      } else {
        timer1.Stop();
      }
      label1.Text = alpha.ToString();
    }
