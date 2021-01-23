    public Form1() {
      InitializeComponent();
      panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
      panel1.MouseUp += new MouseEventHandler(panel1_MouseUp);
      panel1.Paint += new PaintEventHandler(panel1_Paint);
    }
    void panel1_MouseDown(object sender, MouseEventArgs e) {
      foreach (PictureBox pb in panel1.Controls.OfType<PictureBox>()
                                .OrderBy(x => panel1.Controls.GetChildIndex(x))) {
        if (pb.Bounds.Contains(e.Location)) {
          pb.BringToFront();
          pb.Visible = true;
          panel1.Invalidate();
          break;
        }
      }
    }
    void panel1_MouseUp(object sender, MouseEventArgs e) {
      foreach (PictureBox pb in panel1.Controls.OfType<PictureBox>()) {
        pb.Visible = false;
      }
    }
    void panel1_Paint(object sender, PaintEventArgs e) {
      foreach (PictureBox pb in panel1.Controls.OfType<PictureBox>()
                                .OrderByDescending(x => panel1.Controls.GetChildIndex(x))) {
        e.Graphics.FillRectangle(new SolidBrush(pb.BackColor), pb.Bounds);
      }
    }
