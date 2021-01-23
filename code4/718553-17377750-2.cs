    public class Die
    {
        private static readonly Lazy<Die> _d2 = new Lazy<Die>(() => new Die(DyeType.D2));
        private static readonly Lazy<Die> _d3 = new Lazy<Die>(() => new Die(DyeType.D3));
        private static readonly Lazy<Die> _d4 = new Lazy<Die>(() => new Die(DyeType.D4));
        
        public static Die D2 { get { return _d2.Value; } }
        public static Die D3 { get { return _d3.Value; } }
        public static Die D4 { get { return _d4.Value; } }
    
        ...
    }
