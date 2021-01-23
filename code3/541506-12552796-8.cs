    public class CastableClass
    {
        public int IntValue { get; set; }
        public static explicit operator int(CastableClass castable)
        {
            return castable.IntValue;
        }
    }
