    class Point3D {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point3D(double x, double y, double z) {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
    var points = new[] {
        new Point3D(x1, y1, z1),
        new Point3D(x2, y3, z2),
        new Point3D(x3, y3, z3)
    };
    var maxX = points.Max(pt => pt.X);
