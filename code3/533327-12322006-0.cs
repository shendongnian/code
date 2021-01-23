    public class Ant : IEquatable<Ant>
    {
        private string _someField;
        public Ant(string someField)
        {
            this._someField = someField;
        }
        #region Equality members
        public bool Equals(Ant other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return string.Equals(_someField, other._someField);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((Ant) obj);
        }
        public override int GetHashCode()
        {
            return (_someField != null ? _someField.GetHashCode() : 0);
        }
        #endregion
    }
