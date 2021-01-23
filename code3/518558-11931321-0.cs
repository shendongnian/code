    internal interface IPointable
    {
        PointF Point { get; }
    }
    internal class STH : IPointable
    {
        public Point Point { get; set; }
        PointF IPointable.Point
        {
            get { return Point; }
        }
    }
