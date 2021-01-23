    void panel1_Paint(object sender, PaintEventArgs e) {
      foreach (PictureBox pb in panel1.Controls.OfType<PictureBox>()
               .OrderByDescending(x => panel1.Controls.GetChildIndex(x))) {
        e.Graphics.FillRectangle(new SolidBrush(pb.BackColor), pb.Bounds);
      }
    }
