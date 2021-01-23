    public class Junction
    {
        public IConvertible Convertible { get; private set; }
        public IComparable Comparable { get; private set; }
        private Junction() { }
        public static Junction Create<T>(T value) where T : IConvertible, IComparable
        {
            return new Junction
            {
                Convertible = value,
                Comparable = value
            };
        }
    }
