    public class VerticalArrow : Control
    {
        public VerticalArrow()
        {
            Width = 30;
            Height = 100;
            Direction = ArrowDirection.Up;
            ArrowHeight = 4;
            ArrowWidth = 4;
            TrunkWidth = 2;
            SetStyle(ControlStyles.Opaque, true);            
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }
        public ArrowDirection Direction { get; set; }
        public int ArrowHeight { get; set; }
        public int ArrowWidth { get; set; }
        public int TrunkWidth { get; set; }
        Point p1, p2;
        public enum ArrowDirection
        {
            Up,
            Down,
            UpDown
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            p1 = new Point(Width / 2, 0);
            p2 = new Point(Width / 2, Height);
            base.OnSizeChanged(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(Brushes.Transparent, ClientRectangle);
            using (Pen p = new Pen(ForeColor))
            {                
                using (AdjustableArrowCap cap = new AdjustableArrowCap(ArrowWidth, ArrowHeight))
                {
                    if (Direction == ArrowDirection.Up || Direction == ArrowDirection.UpDown) p.CustomStartCap = cap;
                    if (Direction == ArrowDirection.Down || Direction == ArrowDirection.UpDown) p.CustomEndCap = cap;
                }
                p.Width = TrunkWidth;
                e.Graphics.DrawLine(p, p1, p2);
            }
        }
    }
