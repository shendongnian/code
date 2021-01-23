    public struct TilePosition: IEquatable<TilePosition>
    {
        public TilePosition(int horizontalPosition, int verticalPosition)
        {
            _x = horizontalPosition;
            _y = verticalPosition;
        }
        public int HComponent
        {
            get
            {
                return _x;
            }
        }
        public int VComponent
        {
            get
            {
                return _y;
            }
        }
        public static bool operator == (TilePosition lhs, TilePosition rhs)
        {
            return lhs.Equals(rhs);
        }
        public static bool operator != (TilePosition lhs, TilePosition rhs)
        {
            return !lhs.Equals(rhs);
        }
        public bool Equals(TilePosition other)
        {
            return (_x == other._x) && (_y == other._y);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is TilePosition && Equals((TilePosition)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (_x*397) ^ _y;
            }
        }
        private readonly int _x;
        private readonly int _y;
    }
