    public partial class Form1 : Form
    {
        private PictureBox box = new PictureBox();
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            box.Dock = DockStyle.Fill;
            box.BackColor = Color.White;
            box.Paint += new PaintEventHandler(DrawTest);
            this.Controls.Add(box);
        }
        public void DrawTest(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            string text = "Test Text";
            float scale = 1.5F;
            float translate = 200F;
            var flags = TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.PreserveGraphicsTranslateTransform;
            var mx = new Matrix();
            mx.Scale(scale, scale);
            mx.Translate(translate, translate);
            
            g.Clip = new Region(Bounds);
            g.Transform = mx;
        
            Size rendererPSize = Bounds.Size;
            Font f = GetScaledFont(g, new Font("Arial", 12), scale);
            Size rendererRSize = TextRenderer.MeasureText(g, text, f, rendererPSize, flags);
            Rectangle rendererRect = new Rectangle(0, 0, rendererRSize.Width, rendererRSize.Height);
            Rectangle r = GetScaledRect(g, rendererRect, scale);
            TextRenderer.DrawText(g, text, f, realRect, Color.Black, flags);
        }
        private Font GetScaledFont(Graphics g, Font f, float scale)
        {
            return new Font(f.FontFamily,
                            f.SizeInPoints * scale,
                            f.Style,
                            GraphicsUnit.Point,
                            f.GdiCharSet,
                            f.GdiVerticalFont);
        }
        private Rectangle GetScaledRect(Graphics g, Rectangle r, float scale)
        {
            return new Rectangle((int)Math.Ceiling(r.X * scale),
                                (int)Math.Ceiling(r.Y * scale),
                                (int)Math.Ceiling(r.Width * scale),
                                (int)Math.Ceiling(r.Height * scale));
        }
    }
