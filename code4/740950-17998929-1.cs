    public partial class VerticalArrow : UserControl
    {
        public VerticalArrow()
        {
            InitializeComponent();
            Direction = ArrowDirection.Up;                       
        }
        public enum ArrowDirection
        {
            Up,
            Down
        }
        ArrowDirection dir;
        public ArrowDirection Direction
        {
            get { return dir; }
            set
            {
                if (dir != value)
                {
                    dir = value;
                    UpdateRegion();
                }
            }
        }
        //default values of ArrowWidth and ArrowHeight
        int arrowWidth = 14;
        int arrowHeight = 18;
        public int ArrowWidth
        {
            get { return arrowWidth; }
            set
            {
                if (arrowWidth != value)
                {
                    arrowWidth = value;
                    UpdateRegion();                    
                }
            }
        }
        public int ArrowHeight
        {
            get { return arrowHeight; }
            set
            {
                if (arrowHeight != value)
                {
                    arrowHeight = value;
                    UpdateRegion();
                }
            }
        }
        //This will keep the size of the UserControl fixed at design time.
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, Math.Max(ArrowWidth, 4), height, specified);
        }        
        private void UpdateRegion()
        {            
            GraphicsPath gp = new GraphicsPath();
            int dx = ArrowWidth / 2 - 1;
            int dy = ArrowHeight / 2;
            Point p1 = new Point(dx, Direction == ArrowDirection.Up ? dy : 1);
            Point p2 = new Point(ArrowWidth - dx, Direction == ArrowDirection.Up ? dy + 1: 1);
            Point p3 = new Point(ArrowWidth - dx, Direction == ArrowDirection.Up ? ClientSize.Height : ClientSize.Height - dy);
            Point p4 = new Point(dx, Direction == ArrowDirection.Up ? ClientSize.Height : ClientSize.Height - dy);
            Point q1 = Direction == ArrowDirection.Up ? new Point(0, ArrowHeight) : new Point(0, ClientSize.Height - ArrowHeight);
            Point q2 = Direction == ArrowDirection.Up ? new Point(dx, 0) : new Point(dx, ClientSize.Height);
            Point q3 = Direction == ArrowDirection.Up ? new Point(ArrowWidth, ArrowHeight) : new Point(ArrowWidth, ClientSize.Height - ArrowHeight);
            if (Direction == ArrowDirection.Up) gp.AddPolygon(new Point[] { p1, q1, q2, q3, p2, p3, p4 });
            else gp.AddPolygon(new Point[] {p1,p2,p3,q3,q2,q1,p4});
            Region = new Region(gp);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateRegion();
            base.OnSizeChanged(e);
        }
    }
