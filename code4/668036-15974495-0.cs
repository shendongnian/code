    private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    private bool mouseEntered = false;
    public Form1() {
      InitializeComponent();
      timer.Tick += timer_Tick;
      timer.Start();
    }
    protected override void OnMouseEnter(EventArgs e) {
      mouseEntered = true;
      base.OnMouseEnter(e);
    }
    void timer_Tick(object sender, EventArgs e) {
      if (mouseEntered && !this.Bounds.Contains(Cursor.Position)) {
        this.Close();
      }
    }
