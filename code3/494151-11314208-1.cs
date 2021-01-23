    private List<MyRect> myRectangles = new List<MyRect>();
    public Form1() {
      InitializeComponent();
      myRectangles.Add(new MyRect(new Rectangle(10, 10, 64, 16), Color.Blue));
      myRectangles.Add(new MyRect(new Rectangle(20, 48, 16, 64), Color.Red));
    }
    private void panel1_Paint(object sender, PaintEventArgs e) {
      foreach (MyRect mr in myRectangles) {
        using (SolidBrush sb = new SolidBrush(mr.FillColor)) {
          e.Graphics.FillRectangle(sb, mr.Rectangle);
        }
      }
    }
