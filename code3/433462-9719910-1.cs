    public struct Point3D : IFormattable
    {
        public static string DefaultFormat = "F3";
        public float x,y,z;
        public string ToString(string format, IFormatProvider formatProvider)
        {
            string fmt = "({0:#},{1:#},{2:#})".Replace("#", format);
            return string.Format(formatProvider, fmt, x, y, z);
        }
        public string ToString(string format)
        {
            return ToString(format, null);
        }
        public override string ToString()
        {
            return ToString(DefaultFormat);
        }
    }
        static void Main(string[] args)
        {
            Point3D A = new Point3D() { x = (float)Math.PI, y = (float)(-4 / Math.PI), z = (float)(0.005 * Math.PI) };
            Debug.WriteLine(A.ToString());
            Debug.WriteLine(A.ToString("F2"));
        }
