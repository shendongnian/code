    public sealed partial class GafferTape : Form
    {
        private Point _startLocation = Point.Empty;
        private Point _cursorLocation = Point.Empty;
        private bool _drawing;
        private Rectangle _regionRectangle;
        private readonly List<Rectangle> _rectangles = new List<Rectangle>();
    
        public bool AllowDrawing { get; set; }
    
        public GafferTape()
        {
            InitializeComponent();
    
            //TODO: Consider letting the designer handle this.
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            DoubleBuffered = true;
            ShowInTaskbar = false;
            Cursor = Cursors.Cross;
            BackColor = Color.White;
            Opacity = 0.4;
            TransparencyKey = Color.Black;
    
            //TODO: Consider letting the designer handle this.
            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;
            MouseMove += OnMouseMove;
            Paint += OnPaint;
    
            AllowDrawing = true;
    
        }
    
        private void OnMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {
            //I don't allow the user to draw after the rectangles have been drawn. See: buttonInvert_Clic
            if (AllowDrawing)
            {
                _startLocation = mouseEventArgs.Location;
                _drawing = true;
            }
        }
    
        private void OnMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            _drawing = false;
            DialogResult = DialogResult.OK;
            _rectangles.Add(_regionRectangle);
        }
    
        private void OnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (_drawing == false)
                return;
    
            _cursorLocation = mouseEventArgs.Location;
    
            _regionRectangle = new Rectangle(Math.Min(_startLocation.X, _cursorLocation.X),
                                             Math.Min(_startLocation.Y, _cursorLocation.Y),
                                             Math.Abs(_startLocation.X - _cursorLocation.X),
                                             Math.Abs(_startLocation.Y - _cursorLocation.Y));
    
            Invalidate();
        }
    
        private void OnPaint(object sender, PaintEventArgs paintEventArgs)
        {
            foreach (Rectangle rectangle in _rectangles)
                paintEventArgs.Graphics.FillRectangle(Brushes.Black, rectangle);
    
            paintEventArgs.Graphics.FillRectangle(Brushes.Black, _regionRectangle);
        }
    
        private void buttonInvert_Click(object sender, EventArgs e)
        {
            Opacity = 100;
            TransparencyKey = Color.White;
            AllowDrawing = false;
            Cursor = Cursors.Default;
        }
    }
