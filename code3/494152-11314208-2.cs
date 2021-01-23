    void panel1_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        foreach (MyRect mr in myRectangles) {
          if (mr.Rectangle.Contains(e.Location)) {
            ChangeColor(mr, Color.Green);
          }
        }
        panel1.Invalidate();
      }
    }
    private void ChangeColor(MyRect mr, Color newColor) {
      mr.FillColor = newColor;
    }
