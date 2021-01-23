    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.TopMost = true; // make the form always on top
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // hidden border
            this.WindowState = FormWindowState.Maximized; // maximized
            this.MinimizeBox = this.MaximizeBox = false; // not allowed to be minimized
            this.MinimumSize = this.MaximumSize = this.Size; // not allowed to be resized
            this.TransparencyKey = this.BackColor = Color.Red; // the color key to transparent, choose a color that you don't use
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // Set the form click-through
                cp.ExStyle |= 0x80000 /* WS_EX_LAYERED */ | 0x20 /* WS_EX_TRANSPARENT */;
                return cp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // draw what you want
            e.Graphics.FillEllipse(Brushes.Blue, 30, 30, 100, 100);
        }
    }
