    Point parentOffset = Point.Empty;
    bool wasShown = false;
    public Form2() {
      InitializeComponent();
    }
    protected override void OnShown(EventArgs e) {
      parentOffset = new Point(this.Left - this.Owner.Left,
                               this.Top - this.Owner.Top);
      wasShown = true;
      base.OnShown(e);
    }
    protected override void OnLocationChanged(EventArgs e) {
      if (wasShown) {
        this.Owner.Location = new Point(this.Left - parentOffset.X, 
                                        this.Top - parentOffset.Y);
      }
      base.OnLocationChanged(e);
    }
