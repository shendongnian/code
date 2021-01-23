    public class MyEqualityComparer : IEqualityComparer<customPoint>
    {
        public bool Equals(customPoint a, customPoint b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public int GetHashCode(customPoint other)
        {
            return other.X.GetHashCode() * 19 + other.Y.GetHashCode();
        }
    }
    var distinctPoints = myPoints.Distinct(new MyEqualityComparer()).ToList();
