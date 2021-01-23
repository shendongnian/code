    public class RoundedPanel:Panel {
        public int Radius { get; set; }
        public float Thickness { get; set; }
        private Pen _pen;
        private Color _borderColor { get; set; }
        public Color BorderColor {
            get {
                return _borderColor;
            }
            set {
                _borderColor = value;
                _pen = new Pen(_borderColor,Thickness);
            }
        }
        private int _edge = 50;
        public int Edge {
            get {
                return _edge;
            }
            set {
                _edge = value;
                Invalidate();
            }
        }
        public RoundedPanel() : base() {
            _pen = new Pen(BorderColor,Thickness);
            BackColor = Color.White;
            DoubleBuffered = true;
            Radius = 18;
        }
        private Rectangle GetLeftUpper(int e) {
            return new Rectangle(0,0,e,e);
        }
        private Rectangle GetRightUpper(int e) {
            return new Rectangle(Width - e,0,e,e);
        }
        private Rectangle GetRightLower(int e) {
            return new Rectangle(Width - e,Height - e,e,e);
        }
        private Rectangle GetLeftLower(int e) {
            return new Rectangle(0,Height - e,e,e);
        }
        private void ExtendedDraw(PaintEventArgs e) {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(GetLeftUpper(Edge),180,90);
            path.AddLine(Edge,0,Width - Edge,0);
            path.AddArc(GetRightUpper(Edge),270,90);
            path.AddLine(Width,Edge,Width,Height - Edge);
            path.AddArc(GetRightLower(Edge),0,90);
            path.AddLine(Width - Edge,Height,Edge,Height);
            path.AddArc(GetLeftLower(Edge),90,90);
            path.AddLine(0,Height - Edge,0,Edge);
            path.CloseFigure();
            Region = new Region(path);
        }
        private void DrawSingleBorder(Graphics graphics) {
            graphics.DrawArc(_pen,new Rectangle(0,0,Edge,Edge),180,90);
            graphics.DrawArc(_pen,new Rectangle(Width - Edge - 1,-1,Edge,Edge),270,90);
            graphics.DrawArc(_pen,new Rectangle(Width - Edge - 1,Height - Edge - 1,Edge,Edge),0,90);
            graphics.DrawArc(_pen,new Rectangle(0,Height - Edge - 1,Edge,Edge),90,90);
            graphics.DrawRectangle(_pen,0.0f,0.0f,(float)Width - 1.0f,(float)Height - 1.0f);
        }
        private void Draw3DBorder(Graphics graphics) {
            DrawSingleBorder(graphics);
        }
        private void DrawBorder(Graphics graphics) {
            DrawSingleBorder(graphics);
        }
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            ExtendedDraw(e);
            DrawBorder(e.Graphics);
        }
    }
