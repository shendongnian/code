    class Point3DFormatter
    {
        public string Point3DFormat { get; set; }
        public Point3DFormatter()
        {
            Point3DFormat = "{0:0.00} {0:0.00} {0:0.00}";
        }
        string Format(Point3D point)
        {
            return string.Format(Point3DFormat, point.X, point.Y, point.Z);
        }
    }
