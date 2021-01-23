    public class LineMover : Form
    {
      public LineMover()
      {
        this.DoubleBuffered = true;
        this.Paint += new PaintEventHandler(LineMover_Paint);
        this.MouseMove += new MouseEventHandler(LineMover_MouseMove);
        this.MouseDown += new MouseEventHandler(LineMover_MouseDown);
        this.MouseUp += new MouseEventHandler(LineMover_MouseUp);
        this.Lines = new List<GraphLine>()
        {
          new GraphLine (10, 10, 100, 200),
          new GraphLine (10, 150, 120, 40),
        };
      }
      void LineMover_MouseUp(object sender, MouseEventArgs e)
      {
        if (Moving != null)
        {
          this.Capture = false;
          Moving = null;
        }
        RefreshLineSelection(e.Location);
      }
      void  LineMover_MouseDown(object sender, MouseEventArgs e)
      {
        RefreshLineSelection(e.Location);
        if (this.SelectedLine != null && Moving == null)
        {
          this.Capture = true;
          Moving = new MoveInfo 
           {
              Line = this.SelectedLine, 
              StartLinePoint = SelectedLine.StartPoint, 
              EndLinePoint = SelectedLine.EndPoint, 
              StartMoveMousePoint = e.Location 
           };
        }
        RefreshLineSelection(e.Location);
      }
      void LineMover_Paint(object sender, PaintEventArgs e)
      {
        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        foreach (var line in Lines)
        {
          var color = line == SelectedLine ? Color.Red : Color.Black;
          var pen = new Pen(color, 2);
          e.Graphics.DrawLine(pen, line.StartPoint, line.EndPoint);
        }
      }
      void LineMover_MouseMove(object sender, MouseEventArgs e)
      {
        if (Moving != null)
        {
          Moving.Line.StartPoint = new PointF(Moving.StartLinePoint.X + e.X - Moving.StartMoveMousePoint.X, Moving.StartLinePoint.Y + e.Y - Moving.StartMoveMousePoint.Y);
          Moving.Line.EndPoint = new PointF(Moving.EndLinePoint.X + e.X - Moving.StartMoveMousePoint.X, Moving.EndLinePoint.Y + e.Y - Moving.StartMoveMousePoint.Y);
        }
        RefreshLineSelection(e.Location);
      }
      private void RefreshLineSelection(Point point)
      {
        var selectedLine = FindLineByPoint(Lines, point);
        if (selectedLine != this.SelectedLine)
        {
          this.SelectedLine = selectedLine;
          this.Invalidate();
        }
        if (Moving != null)
          this.Invalidate();
        this.Cursor =
            Moving != null ? Cursors.Hand :
            SelectedLine != null ? Cursors.SizeAll :
              Cursors.Default;
      }
      public List<GraphLine> Lines = new List<GraphLine>();
      GraphLine SelectedLine = null;
      MoveInfo Moving = null;
      static GraphLine FindLineByPoint(List<GraphLine> lines, Point p)
      {
        var size = 10;
        var buffer = new Bitmap(size * 2, size * 2);
        foreach (var line in lines)
        {
          //draw each line on small region around current point p and check pixel in point p 
          using (var g = Graphics.FromImage(buffer))
          {
            g.Clear(Color.Black);
            g.DrawLine(new Pen(Color.Green, 3), line.StartPoint.X - p.X + size, line.StartPoint.Y - p.Y + size, line.EndPoint.X - p.X + size, line.EndPoint.Y - p.Y + size);
          }
          if (buffer.GetPixel(size, size).ToArgb() != Color.Black.ToArgb())
            return line;
        }
        return null;
      }
      public static void Main()
      {
        Application.Run(new LineMover());
      }
    }
    public class MoveInfo
    {
      public GraphLine Line;
      public PointF StartLinePoint;
      public PointF EndLinePoint;
      public Point StartMoveMousePoint;
    }
    public class GraphLine
    {
      public GraphLine(float x1, float y1, float x2, float y2)
      {
        this.StartPoint = new PointF(x1, y1);
        this.EndPoint = new PointF(x2, y2);
      }
      public PointF StartPoint;
      public PointF EndPoint;
    }
