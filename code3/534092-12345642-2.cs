    public partial class CustomControl1 : ToolStripMenuItem 
    {
        Rectangle r;
        bool entered;
        public CustomControl1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SolidBrush brush;
            r = new Rectangle(this.Bounds.Width - 20, 2, 16, 17);
            // If MouseEnter Del(Close Icon)
            if (entered)
            {
                brush = new SolidBrush(Color.LightBlue);
                e.Graphics.FillRectangle(brush, r);
                brush.Color = Color.Blue;
                e.Graphics.DrawRectangle(new Pen(brush, 1), r);
            }
            // If Mouse Not Entered Del(Close Icone)
            if (!entered)
            {
                brush = new SolidBrush(Color.FromKnownColor(KnownColor.Transparent));
                e.Graphics.FillRectangle(brush, r);
                brush.Color = Color.FromKnownColor(KnownColor.Transparent);
                e.Graphics.DrawRectangle(new Pen(brush, 1), r);
            }
            //Code for Drawing Cross Lines
            brush = new SolidBrush(Color.Gray);
            Rectangle rCross = new Rectangle(this.Bounds.Width - 15, 8, 6, 6);
            e.Graphics.DrawLine(new Pen(brush, 2), new Point(rCross.Right, rCross.Top), new Point(rCross.Left, rCross.Bottom));
            e.Graphics.DrawLine(new Pen(brush, 2), new Point(rCross.Left, rCross.Top), new Point(rCross.Right, rCross.Bottom));
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (r.Contains(e.X, e.Y) && !entered)
            {
                entered = true;
                Invalidate(r);
            }
            else if (!r.Contains(e.X, e.Y) && entered)
            {
                entered = false;
                Invalidate(r);
            }
        }
    }
