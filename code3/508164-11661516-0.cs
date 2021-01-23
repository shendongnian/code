    public partial class Form2 : Form {
      public Image MyImage { get; set; }
      public Form2() {
        InitializeComponent();
      }
      protected override void OnPaint(PaintEventArgs e) {
        if (MyImage != null) {
          e.Graphics.DrawImage(MyImage, 0, 0);
        }
        base.OnPaint(e);
      }
    }
