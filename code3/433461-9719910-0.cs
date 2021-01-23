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
            NumberFormatInfo info = new NumberFormatInfo();
            info.NumberDecimalDigits = 2;
            return ToString(format, info );
        }
        public override string ToString()
        {
            return ToString(DefaultFormat);
        }
    }
