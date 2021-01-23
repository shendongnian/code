    public struct Vector3 {
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }
        public float Length {
            get { return (float)Math.Sqrt(X * X + Y * Y + Z * Z); }
        }
        Vector3 Normalized {
            get {
                float l = Length;
                return new Vector3(X / l, Y / l, Z / l);
            }
        }
    }
