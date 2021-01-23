    class FreeformLine : Shape
    {
        private List<Point> _points = new List<Point>();
        public FreeformLine(Point startLocation)
        {
            _points.Add(startLocation);
        }
        public override void Paint(PaintEventArgs e)
        {
            if (_points.Count >= 2) {
                e.Graphics.DrawLines(Pens.Black, _points.ToArray());
            }
        }
        public override void UpdateShape(Point newLocation)
        {
            const int minDist = 3;
            // Add new point only if it has a minimal distance from the last one.
            // This creates a smoother line.
            Point last = _points[_points.Count - 1];
            if (Math.Abs(newLocation.X - last.X) >= minDist ||
                Math.Abs(newLocation.Y - last.Y) >= minDist)
            {
                _points.Add(newLocation);
            }
        }
    }
