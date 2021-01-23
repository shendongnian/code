    Bitmap bmp;
    Point lastPoint;
    public Form1() {
      InitializeComponent();
      bmp = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height, 
                       System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
      panel1.MouseDown += panel1_MouseDown;
      panel1.MouseMove += panel1_MouseMove;
      panel1.Paint += panel1_Paint;
    }
    void panel1_Paint(object sender, PaintEventArgs e) {
      e.Graphics.DrawImage(bmp, Point.Empty);
    }
    void panel1_MouseMove(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        using (Graphics g = Graphics.FromImage(bmp)) {
          g.DrawLine(Pens.Black, lastPoint, e.Location);
        }
        lastPoint = e.Location;
        panel1.Invalidate();
      }
    }
    void panel1_MouseDown(object sender, MouseEventArgs e) {
      lastPoint = e.Location;
    }
