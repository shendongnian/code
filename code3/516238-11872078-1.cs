    public Form1() {
      InitializeComponent();
      panel1.MouseClick += new MouseEventHandler(panel1_MouseClick);
      panel1.Paint += new PaintEventHandler(panel1_Paint);
    }
    void panel1_Paint(object sender, PaintEventArgs e) {
      foreach (PictureBox pb in panel1.Controls.OfType<PictureBox>()
               .OrderByDescending(x => panel1.Controls.GetChildIndex(x))) {
        e.Graphics.FillRectangle(new SolidBrush(pb.BackColor), pb.Bounds);
      }
    }
    void panel1_MouseClick(object sender, MouseEventArgs e) {
      foreach (PictureBox pb in panel1.Controls.OfType<PictureBox>()
               .OrderBy(x => panel1.Controls.GetChildIndex(x))) {
        if (pb.Bounds.Contains(e.Location)) {
          pb.BringToFront();
          panel1.Invalidate();
          break;
        }
      }
    }
