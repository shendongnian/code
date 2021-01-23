    void panel1_MouseClick(object sender, MouseEventArgs e) {
      foreach (PictureBox pb in panel1.Controls.OfType<PictureBox>()
                                .OrderBy(x => panel1.Controls.GetChildIndex(x))) {
        if (pb.Bounds.Contains(e.Location)) {
          foreach (PictureBox hidePB in panel1.Controls.OfType<PictureBox>()) {
            hidePB.Visible = false;
          }
          pb.Visible = true;
          pb.BringToFront();
          break;
        }
      }
    }
