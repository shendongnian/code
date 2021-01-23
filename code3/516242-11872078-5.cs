    void panel1_MouseMove(object sender, MouseEventArgs e) {
      if (dragBox != null && !isDragging) {
        isDragging = true;
        panel1.DoDragDrop(dragBox, DragDropEffects.Move);
      }
    }
    void panel1_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        foreach (PictureBox pb in panel1.Controls.OfType<PictureBox>()
                 .OrderBy(x => panel1.Controls.GetChildIndex(x))) {
          if (pb.Bounds.Contains(e.Location)) {
            pb.BringToFront();
            pb.Visible = true;
            dragBox = pb;
            dragOffset = new Point(e.X - pb.Left, e.Y - pb.Top);
            panel1.Invalidate();
            break;
          }
        }
      }
    }
    void panel1_MouseUp(object sender, MouseEventArgs e) {
      foreach (PictureBox pb in panel1.Controls.OfType<PictureBox>()) {
        pb.Visible = false;
      }
      dragBox = null;
      isDragging = false;
    }
