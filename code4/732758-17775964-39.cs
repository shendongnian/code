    public struct Vector3
    {
        public static readonly Vector3 Zero = new Vector3(0, 0, 0);
        public readonly float X;
        public readonly float Y;
        public readonly float Z;
 
        public float Length { return Math.Sqrt(X * X + Y * Y + Z * Z); }
    
        public Vector3(float x, float y, float z)
        {
             X = x;
             Y = y;
             Z = z;
        }
    
        public static Vector3 operator +(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
        }
        public static Vector3 operator -(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);
        }
        public static Vector3 operator *(float scalar, Vector3 vector)
        {
            return new Vector3(scalar * vector.X, scalar * vector.Y, scalar * vector.Z);
        }
    
        public static float DotProduct(Vector3 vector1, Vector3 vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
        }
        public static Vector3 CrossProduct(Vector3 vector1, Vector3 vector2)
        {
            return return new Vector3(vector1.Y * vector2.Z - vector1.Z * vector2.Y,
                                      vector1.Z * vector2.X - vector1.X * vector2.Z,
                                      vector1.X * vector2.Y - vector1.Y * vector2.X);
        }
    }
