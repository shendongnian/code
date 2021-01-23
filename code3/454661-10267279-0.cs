    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = this.BackColor = Color.Fuchsia;
            this.Opacity = 0.3;
            var overlay = new Form();
            overlay.FormBorderStyle = FormBorderStyle.None;
            overlay.TransparencyKey = overlay.BackColor = Color.Fuchsia;
            overlay.StartPosition = FormStartPosition.Manual;
            overlay.Location = this.Location;
            overlay.MouseDown += HandleIconClick;
            this.Resize += delegate { overlay.Size = this.Size; };
            this.LocationChanged += delegate { overlay.Location = this.Location; };
            overlay.Paint += PaintIcons;
            this.Paint += PaintBackground;
            this.Load += delegate { overlay.Show(this); };
        }
        private void PaintBackground(object sender, PaintEventArgs e) {
            var rc = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            using (var br = new LinearGradientBrush(rc, Color.Gainsboro, Color.Yellow, 0f)) {
                e.Graphics.FillRectangle(br, rc);
            }
        }
        private void PaintIcons(object sender, PaintEventArgs e) {
            e.Graphics.DrawIcon(Properties.Resources.ExampleIcon1, 50, 30);
            // etc...
        }
        void HandleIconClick(object sender, MouseEventArgs e) {
            // TODO
        }
    }
