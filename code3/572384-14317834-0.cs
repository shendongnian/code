    public sealed partial class RegionForm : Form
    {
        private Bitmap bitmap;
        private bool mouseDown;
        private Rectangle newRegion;
        private Rectangle oldRegion;
        private Point startPoint;
        public RegionForm()
        {
            InitializeComponent();
            Location = Screen.PrimaryScreen.Bounds.Location;
            Size = Screen.PrimaryScreen.Bounds.Size;
            Cursor = Cursors.Cross;
            TopMost = true;
            ShowInTaskbar = false;
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer, true);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            bitmap = new Bitmap(this.ClientSize.Width,
                        this.ClientSize.Height,
                        PixelFormat.Format32bppPArgb);
            this.DrawToBitmap(bitmap, this.ClientRectangle);
            startPoint = e.Location;
            mouseDown = true;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            mouseDown = false;
            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }
            // reset regions
            newRegion = Rectangle.Empty;
            oldRegion = Rectangle.Empty;
            // invalidate all
            Invalidate(true);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (mouseDown)
            {
                // calculate new region
                var vector = Point.Subtract(e.Location, new Size(startPoint));
                newRegion = new Rectangle(System.Math.Min(startPoint.X, e.Location.X), System.Math.Min(startPoint.Y, e.Location.Y), System.Math.Abs(vector.X), System.Math.Abs(vector.Y));
                // invalidate only the area of interest
                var invalidate = Rectangle.Union(oldRegion, newRegion);
                Invalidate(invalidate, true);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.None;
            ClearRegion(e.Graphics, bitmap, oldRegion);
            DrawRegion(e.Graphics, newRegion);
            // remember which region has been handled
            oldRegion = newRegion;
        }
        static void DrawRegion(Graphics g, Rectangle region)
        {
            if (g == null || region == Rectangle.Empty)
                return;
            //Draw a red rectangle
            g.FillRectangle(Brushes.Red, region);
        }
        static void ClearRegion(Graphics g, Bitmap bitmap, Rectangle region)
        {
            if (g == null || region == Rectangle.Empty || bitmap == null)
                return;
            // take only the selected region from the original image and draw that part
            g.DrawImage(bitmap, region, region, GraphicsUnit.Pixel);
        }
