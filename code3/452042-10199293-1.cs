    private Rectangle areaRect = new Rectangle(100, 100, 300, 300);
    private Rectangle oldRect;
    private int dragHandle = 0;
    private Point dragPoint;
    public Form1() {
      InitializeComponent();
      this.DoubleBuffered = true;
    }
    protected override void OnMouseDown(MouseEventArgs e) {
      for (int i = 1; i < 9; i++) {
        if (GetHandleRect(i).Contains(e.Location)) {
          dragHandle = i;
          oldRect = areaRect;
          dragPoint = GetHandlePoint(i);
        }
      }
      base.OnMouseDown(e);
    }
    protected override void OnMouseMove(MouseEventArgs e) {
      if (dragHandle == 1) {
        // to do
      } else if (dragHandle == 2) {
        int diff = dragPoint.X - e.Location.X;
        areaRect = new Rectangle(oldRect.Left - diff, oldRect.Top, oldRect.Width + diff, oldRect.Height);
      } else if (dragHandle == 7) {
        int diff = dragPoint.X - e.Location.X;
        areaRect = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width - diff, oldRect.Height);
      }
      if (dragHandle > 0)
        this.Invalidate();
      base.OnMouseMove(e);
    }
    protected override void OnMouseUp(MouseEventArgs e) {
      dragHandle = 0;
      base.OnMouseUp(e);
    }
    protected override void OnPaint(PaintEventArgs e) {
      e.Graphics.DrawRectangle(Pens.Red, areaRect);
      for (int i = 1; i < 9; i++) {
        e.Graphics.FillRectangle(Brushes.DarkRed, GetHandleRect(i));
      }
      base.OnPaint(e);
    }
