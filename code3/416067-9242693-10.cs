    class StraightLine : Shape
    {
        private Point _first;
        private Point _last;
        public StraightLine(Point startLocation)
        {
            _first = startLocation;
        }
        public override void Paint(PaintEventArgs e)
        {
            Pen pen2 = new Pen(Color.Red, 2);
            e.Graphics.DrawLine(pen2, _first, _last);
        }
        public override void UpdateShape(Point newLocation)
        {
            _last = newLocation;
        }
    }
