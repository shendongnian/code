    private Point startingPoint = Point.Empty;
    private Point movingPoint = Point.Empty;
    private bool panning = false;
    void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
      panning = true;
      startingPoint = new Point(e.Location.X - movingPoint.X,
                                e.Location.Y - movingPoint.Y);
    }
    void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
      panning = false;
    }
    void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
      if (panning) {
        movingPoint = new Point(e.Location.X - startingPoint.X, 
                                e.Location.Y - startingPoint.Y);
        pictureBox1.Invalidate();
      }
    }
    void pictureBox1_Paint(object sender, PaintEventArgs e) {
      e.Graphics.Clear(Color.White);
      e.Graphics.DrawImage(Image, movingPoint);
    }
