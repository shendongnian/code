    public static partial class ShortExtensionMethods
    {
        public static short SafeValue(this short? self)
        {
            return self == null ? 0 : self.Value;
        }
    }
