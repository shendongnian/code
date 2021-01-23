    public class Coordinate
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public override int GetHashCode()
        {
            Int32 hash = 17;
            hash = hash * 23 + X;
            hash = hash * 23 + Y;
            return hash;
        }
        public override Boolean Equals(object obj)
        {
            Coordinate other = obj as Coordinate;
            if (other != null)
            {
                return (other.X == X) && (other.Y == Y);
            }
            return false;
        }
    }
