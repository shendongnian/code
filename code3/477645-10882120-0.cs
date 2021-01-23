        public static double GetLength(this Geometry geo)
        {
            PathGeometry path = geo.GetFlattenedPathGeometry();
            
            double length = 0.0;
            foreach (PathFigure pf in path.Figures)
            {
                Point start = pf.StartPoint;
                foreach (PolyLineSegment seg in pf.Segments)
                {
                    foreach (Point point in seg.Points)
                    {
                        length += Distance(start, point);
                        start = point;
                    }
                }
            }
            return length;
        }
        private static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X,2) + Math.Pow(p1.Y - p2.Y,2));
        }
