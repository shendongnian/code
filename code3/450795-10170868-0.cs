    public class Coordinates
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    
        public int X { get; private set; }
        public int Y { get; private set; }
    
        public override bool Equals(object obj)
        {
            if (!(obj is Coordinates))
            {
                return false;
            }
            Coordinates coordinates = (Coordinates)obj;
            return ((coordinates.X == this.X) && (coordinates.Y == this.Y));
        }
    
        public override int GetHashCode()
        {
            return (X ^ Y);
        }
    }
