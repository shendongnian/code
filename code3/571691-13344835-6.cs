    public class Custom<T> : GenericConstraint<string, int, byte>
    {
        public Custom() : base(typeof(T))
        {
        }
    }
