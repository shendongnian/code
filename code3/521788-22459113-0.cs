        public class NCPoint
        {
            public int X { get; private set; }
            public int Y { get; private set; }
            public int Z { get; private set; }
            public NCPoint(int x, int y, int z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }
            public NCPoint WithX (int x)
            {
                return x == X ? this : new NCPoint(x, Y, Z);
            }
            public NCPoint WithY(int y)
            {
                return y == Y ? this : new NCPoint(X, y, Z);
            }
            public NCPoint WithZ(int z)
            {
                return z == Z ? this : new NCPoint(X, Y, z);
            }
        }
