    class RectangleShape : Shape
    {
        protected bool _filled;
        protected Rectangle _rect;
        protected Point _start;
        public RectangleShape(Point startLocation, bool filled)
        {
            _start = startLocation;
            _rect = new Rectangle(startLocation.X, startLocation.Y, 0, 0);
            _filled = filled;
        }
        public override void Paint(PaintEventArgs e)
        {
            if (_filled) {
                using (SolidBrush brush = new SolidBrush(Color.Red)) {
                    e.Graphics.FillRectangle(brush, _rect);
                }
            } else {
                using (Pen pen = new Pen(Color.Red, 2)) {
                    e.Graphics.DrawRectangle(pen, _rect);
                }
            }
        }
        public override void UpdateShape(Point newLocation)
        {
            int x = Math.Min(_start.X, newLocation.X);
            int y = Math.Min(_start.Y, newLocation.Y);
            int width = Math.Abs(newLocation.X - _start.X);
            int height = Math.Abs(newLocation.Y - _start.Y);
            _rect = new Rectangle(x, y, width, height);
        }
    }
