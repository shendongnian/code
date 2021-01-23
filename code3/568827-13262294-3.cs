    public class Duration : IEquatable<Duration>
    {
        protected double _length;
        /// <summary>
        /// Gets or Sets the duration in Miliseconds.
        /// </summary>
        public virtual double Length
        {
            get { return _length; }
            set { _length = value; }
        }
        // removed all the other code that as it was irrelevant
        public bool Equals(Duration other)
        {
            // First two lines are just optimizations
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _length.Equals(other._length);
        }
        public override bool Equals(object obj)
        {
            // Again just optimization
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            // Actually check the type, should not throw exception from Equals override
            if (obj.GetType() != this.GetType()) return false;
            // Call the implementation from IEquatable
            return Equals((Duration) obj);
        }
        public override int GetHashCode()
        {
            // Constant because equals tests mutable member.
            // This will give poor hash performance, but will prevent bugs.
            return 0;
        }
    }
