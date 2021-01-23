    struct Vector2
    {
        public readonly float X;
        public readonly float Y;
        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(b.X - a.X, b.Y - a.Y);
        }
        public static Vector2 operator *(Vector2 a, float d)
        {
            return new Vector2(a.X * d, a.Y * d);
        }
        public override string ToString()
        {
            return string.Format("[{0}, {1}]", X, Y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector2 a = new Vector2(1, 1);
            Vector2 b = new Vector2(3, 1);
            float distance = 0.5f; // From 0.0 to 1.0.
            Vector2 c = (a - b) * distance;
            Console.WriteLine(c);
        }
    }
