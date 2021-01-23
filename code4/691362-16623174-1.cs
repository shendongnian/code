    public sealed partial class ColouredSquareHolder: Control
    {
        ColouredSquareCollection _squares;
        public ColouredSquareHolder()
        {
            ResizeRedraw = true;
            DoubleBuffered = true;
            InitializeComponent();
        }
        public ColouredSquareCollection Squares
        {
            get
            {
                return _squares;
            }
            set
            {
                _squares = value;
                Invalidate();     // Redraw after squares change.
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (_squares == null)
                return;
            int w = Width;
            int h = Height;
            int nx = _squares.Width;
            int ny = _squares.Height;
            var canvas = pe.Graphics;
            for (int yi = 0; yi < ny; ++yi)
            {
                for (int xi = 0; xi < nx; ++xi)
                {
                    int x1 = (xi*w)/nx;
                    int dx = ((xi + 1)*w)/nx - x1;
                    int y1 = (yi*h)/ny;
                    int dy = ((yi+1)*h)/ny - y1;
                    using (var brush = new SolidBrush(_squares[xi, yi]))
                        canvas.FillRectangle(brush, x1, y1, dx, dy);
                }
            }
        }
    }
