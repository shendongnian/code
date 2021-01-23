    public sealed class LineIntersectionChecker
    {
        private readonly PointF _p1;
        private readonly PointF _p2;
        private readonly double _slope;
        private readonly double _yIntersect;
        private readonly double _tolerance;
        private readonly double _x1;
        private readonly double _x2;
        private readonly double _y1;
        private readonly double _y2;
        private readonly bool   _isHorizontal;
        private readonly bool   _isVertical;
        public LineIntersectionChecker(PointF p1, PointF p2, double tolerance = 1.0)
        {
            _p1 = p1;
            _p2 = p2;
            _tolerance = tolerance;
            _isVertical   = (Math.Abs(p1.X - p2.X) < 0.01);
            _isHorizontal = (Math.Abs(p1.Y - p2.Y) < 0.01);
            if (_isVertical || _isHorizontal) // Too steep or flat?
            {
                _slope      = double.NaN;
                _yIntersect = double.NaN;
            }
            else // Useable.
            {
                _slope = (p1.Y - p2.Y)/(double) (p1.X - p2.X);
                _yIntersect = p1.Y - _slope * p1.X ;
            }
            if (_p1.X < _p2.X)
            {
                _x1 = _p1.X - _tolerance;
                _x2 = _p2.X + _tolerance;
            }
            else
            {
                _x1 = _p2.X - _tolerance;
                _x2 = _p1.X + _tolerance;
            }
            if (_p1.Y < _p2.Y)
            {
                _y1 = _p1.Y - _tolerance;
                _y2 = _p2.Y + _tolerance;
            }
            else
            {
                _y1 = _p2.Y - _tolerance;
                _y2 = _p1.Y + _tolerance;
            }
        }
        public bool IsOnLine(PointF p)
        {
            if (!inRangeX(p.X) || !inRangeY(p.Y))
                return false;
            if (_isHorizontal)
                return inRangeY(p.Y);
            if (_isVertical)
                return inRangeX(p.X);
            double expectedY = p.X*_slope + _yIntersect;
            return (Math.Abs(expectedY - p.Y) <= _tolerance);
        }
        private bool inRangeX(double x)
        {
            return (_x1 <= x) && (x <= _x2);
        }
        private bool inRangeY(double y)
        {
            return (_y1 <= y) && (y <= _y2);
        }
    }
