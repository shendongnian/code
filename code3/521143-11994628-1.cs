    private Point start = Point.Empty;
    void pictureBoxPackageView_MouseUp(object sender, MouseEventArgs e) {
      _mapPackageIsMoving = false;
    }
    void pictureBoxPackageView_MouseMove(object sender, MouseEventArgs e) {
      if (_mapPackageIsMoving) {
        pictureBoxPackageView.Location = new Point(
                                 pictureBoxPackageView.Left + (e.X - start.X), 
                                 pictureBoxPackageView.Top + (e.Y - start.Y));
      }
    }
    void pictureBoxPackageView_MouseDown(object sender, MouseEventArgs e) {
      start = e.Location;
      _mapPackageIsMoving = true;
    }
