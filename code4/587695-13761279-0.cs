    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e) {
            var s = "Hiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii";
            e.Graphics.DrawString(s, this.Font, Brushes.Black, 0, 0);
            TextRenderer.DrawText(e.Graphics, s, this.Font, new Point(0, this.Font.Height), Color.Black);
            base.OnPaint(e);
        }
    }
