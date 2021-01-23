    public struct Point3D
    {
        public double x, y, z;        
    }
    public static class Extensions
    {
        public static ICoordinate[] ToCoord(this Point3D[] points)
        {
            ICoordinate[] res = new ICoordinate[points.Length];
            unchecked
            {
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = new Coordinate(points[i].x, points[i].y, points[i].z);
                }
            }
            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point3D[] array1 = new Point3D[N];
            // Fill the array ..
            ICoordinate[] array2 = array1.ToCoord();
        }
    }
