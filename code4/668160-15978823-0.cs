    public static class Conversions
    {
        public static string UpperString<T>(T self)
        {
            return self.ToString().ToUpper();
        }
        public static string LowerString<T>(T self)
        {
            return self.ToString().ToLower();
        }
    }
    public static T Read<T>(T input, Func<T, string> conversion)
    {
        // Do-whatchya-do
    }
    void Main()
    {
        Read<SomeObj>(new SomeObj(), Conversions.UpperString<SomeObj>);
        Read<SomeObj>(new SomeObj(), Conversions.LowerString<SomeObj>);
    }
