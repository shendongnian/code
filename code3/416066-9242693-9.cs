    class FreeformLine : Shape
    {
        private List<Point> _points = new List<Point>();
        public FreeformLine(Point startLocation)
        {
            _points.Add(startLocation);
        }
        public override void Paint(PaintEventArgs e)
        {
            if (_points.Count > 2) {
                e.Graphics.DrawLines(Pens.Black, _points.ToArray());
            }
        }
        public override void UpdateShape(Point newLocation)
        {
            _points.Add(newLocation);
        }
    }
