    public UserControl1() {
      InitializeComponent();
      this.DoubleBuffered = true;
      this.ResizeRedraw = true;
    }
    protected override void OnPaint(PaintEventArgs e) {
      base.OnPaint(e);
      e.Graphics.Clear(Color.White);
      for (int i = 0; i < Set_Of_Connections.Count; ++i)
      {
         DrawLine(e.Graphics, 
                  Set_Of_Connections[i].ins.cb,
                  Set_Of_Connections[i].outs.cb,
                  Color.Green);
      }
    }
    protected override void OnMouseWheel(MouseEventArgs e) {
      base.OnMouseWheel(e);
      this.Invalidate();
    }
    protected override void OnScroll(ScrollEventArgs se) {
      base.OnScroll(se);
      this.Invalidate();
    }
