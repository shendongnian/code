    public sealed class Empty
    {
        private static readonly Lazy<Empty> lazy =
            new Lazy<Empty>(() => new Empty());
        public override string ToString()
        {
            return "";
        }
        public static object _ { get { return lazy.Value; } }
        private Empty()
        {
        }
    }
