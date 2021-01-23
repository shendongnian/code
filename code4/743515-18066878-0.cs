    public class ePoint : eViewModel, IEquatable<ePoint>
    {
        public double X;
        
        public double Y;
        
        // Methods
        #region IEquatable Overrides
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(obj, null)) { return false; }
            if (Object.ReferenceEquals(this, obj)) { return true; }
            if (!(obj is ePoint)) { return false; }
            return Equals((ePoint)obj);
        }
        public bool Equals(ePoint other)
        {
            return X == other.X && Y == other.Y;
        }
        public override int GetHashCode()
        {
            return (int)Math.Pow(X,Y);
        }
        #endregion
