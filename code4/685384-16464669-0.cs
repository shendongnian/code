    public partial class Form1 : Form {
      Bitmap bmap;
      public Form1() {
        InitializeComponent();
        bmap = new Bitmap(panel1.ClientWidth, panel1.ClientHeight);
        panel1.MouseDown += panel1_MouseDown;
        panel1.Paint += panel1_Paint;
      }
      void panel1_Paint(object sender, PaintEventArgs e) {
        e.Graphics.DrawImage(bmap, Point.Empty);
      }
      void panel1_MouseDown(object sender, MouseEventArgs e) {
        using (Graphics g = Graphics.FromImage(bmap)) {
          g.FillEllipse(Brushes.Black, e.X, e.Y, 10, 10);
        }
        panel1.Invalidate();
      }
      private void clearToolStripMenuItem_Click(object sender, EventArgs e) {
        using (Graphics g = Graphics.FromImage(bmap)) {
          g.Clear(Color.White);
        }
        panel1.Invalidate();
      }
      private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
        bmap.Save(@"c:\temp\bmap.bmp");
      }
    }
