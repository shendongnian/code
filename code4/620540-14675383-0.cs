    public partial class DrawingPanel : Panel
    {
        private List<Point> drawnPoints;
        public DrawingPanel()
        {
            InitializeComponent();
            drawnPoints = new List<Point>();
            
            // Double buffering is needed for drawing this smoothly,
            // else we'll experience flickering
            // since we call invalidate for the whole control.
            this.DoubleBuffered = true; 
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // NOTE: You would want to optimize the object allocations, 
            // e.g. creating the brush and pen in the constructor
            using (Brush brush = new SolidBrush(Color.Red))
            {
                using (Pen pen = new Pen(brush, 1))
                {
                    // Redraw the stuff:
                    for (int i = 1; i < drawnPoints.Count; i++)
                    {
                        e.Graphics.DrawLine(pen, drawnPoints[i - 1], drawnPoints[i]);
                    }
                }
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            // Just saving the painted data here:
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                drawnPoints.Add(e.Location);
                this.Invalidate();
            }
        }
        public void SaveBitmap(string location)
        {
            Bitmap bmp = new Bitmap((int)Width, (int)Height);
            DrawToBitmap(bmp, new Rectangle(0, 0, Width, Height));
            using (FileStream saveStream = new FileStream(location + ".bmp", FileMode.OpenOrCreate))
            {
                bmp.Save(saveStream, ImageFormat.Bmp);
            }                       
        }
    }
