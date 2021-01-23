    public class Point : IComparable<Point>, IEquatable<Point>
    {
        public DateTime x;
        public double y;
        public uint z;
    
        public Point(DateTime dateTime, double rate, uint sequence)
        {
            x = dateTime;
            y = rate;
            z = sequence;
        }
    
        public int Compare(Point a, Point b)
        {
            // Equal.
            if (a.z == b.z)
            {
                return 0;
            }
            // Less than.
            else
            if ((a.z < b.z))
            {
                return -1;
            }
            // Greater than.
            else
            {
                return 1;
            }
        }
    
        public int CompareTo(Point point)
        {
            return Compare(this, point);
        }
    
        public static int operator- (Point a, Point b)
        {
            return (int)(a.z - b.z);
        }
    
        public bool Equals(Point point)
        {
            return z == point.z;
        }
    }
"""
