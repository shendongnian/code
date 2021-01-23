    public class SelectionTool : Panel {
      Form parent;
      Point _StartingPoint;
      public SelectionTool(Form parent, Point startingPoint) {
        this.DoubleBuffered = true;
        this.Location = startingPoint;
        //this.endingPoint = startingPoint;
        _StartingPoint = startingPoint;
        this.parent = parent;
        this.parent.Controls.Add(this);
        this.parent.MouseMove += new MouseEventHandler(parent_MouseMove);
        this.BringToFront();
        this.Size = new Size(0, 0);
      }
      public void parent_MouseMove(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left) {
          int minX = Math.Min(e.Location.X, _StartingPoint.X);
          int minY = Math.Min(e.Location.Y, _StartingPoint.Y);
          int maxX = Math.Max(e.Location.X, _StartingPoint.X);
          int maxY = Math.Max(e.Location.Y, _StartingPoint.Y);
          this.SetBounds(minX, minY, maxX - minX, maxY - minY);
          this.Invalidate();
        }
      }
      protected override void OnPaint(PaintEventArgs e) {
        base.OnPaint(e);
        this.BackColor = Color.Blue;
      }
    }
