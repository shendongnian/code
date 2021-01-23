    class Ellipse : RectangleShape
    {
        public Ellipse(Point startLocation, bool filled)
            : base(startLocation, filled)
        {
        }
        public override void Paint(PaintEventArgs e)
        {
            if (_filled) {
                using (SolidBrush brush = new SolidBrush(Color.Red)) {
                    e.Graphics.FillEllipse(brush, _rect);
                }
            } else {
                using (Pen pen = new Pen(Color.Red, 2)) {
                    e.Graphics.DrawEllipse(pen, _rect);
                }
            }
        }
    }
