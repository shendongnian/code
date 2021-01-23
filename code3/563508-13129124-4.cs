    private class Line {
      public Point Starting { get; set; }
      public Point Ending { get; set; }
      public Line(Point starting, Point ending) {
        this.Starting = starting;
        this.Ending = ending;
      }
    }
    List<Line> lines = new List<Line>();
    private Point downPoint = Point.Empty;
    private Point movePoint = Point.Empty;
    private bool movingLine = false;
    public Form1() {
      InitializeComponent();
      panel1.Paint += panel1_Paint;
      panel1.MouseDown += panel1_MouseDown;
      panel1.MouseMove += panel1_MouseMove;
      panel1.MouseUp += panel1_MouseUp;
    }
    void panel1_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        downPoint = e.Location;
      }
    }
    void panel1_MouseMove(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        movingLine = true;
        movePoint = e.Location;
        panel1.Invalidate();
      }
    }
    void panel1_MouseUp(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        movingLine = false;
        lines.Add(new Line(downPoint, e.Location));
        panel1.Invalidate();
      }
    }
    void panel1_Paint(object sender, PaintEventArgs e) {
      e.Graphics.Clear(Color.White);
      foreach (Line l in lines) {
        e.Graphics.DrawLine(Pens.Black, l.Starting, l.Ending);
      }
      if (movingLine) {
        e.Graphics.DrawLine(Pens.Black, downPoint, movePoint);
      }
    }
