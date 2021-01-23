    class RectangleShape : Shape
    {
        protected bool _filled;
        protected Rectangle _rect;
        public RectangleShape(Point startLocation, bool filled)
        {
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
            _rect = new Rectangle(_rect.Left, _rect.Top, newLocation.X - _rect.Left, newLocation.Y - _rect.Top);
        }
    }
