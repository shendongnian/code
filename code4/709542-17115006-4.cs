        public class Line
        {
            private Point _p1;
            public Point P1
            {
                get
                {
                    return _p1;
                }
            }
            private Point _p2;
            public Point P2
            {
                get
                {
                    return _p2;
                }
            }
            private double _length;
            public double Length
            {
                get
                {
                    return _length;
                }
            }
            public Line(Point p1, Point p2)
            {
                _p1 = p1;
                _p2 = p2;
                _length = Math.Sqrt( 
                        Math.Pow( _p2.X - _p1.X, 2 ) + 
                        Math.Pow( _p2.Y - _p1.Y, 2 ) 
                    );
            }
        }
