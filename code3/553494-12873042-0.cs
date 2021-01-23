    public static class SomeInterfaceExtensions
    {
        // Extension
        public static string GetName(this ISomeInterface some)
        {
            return some.GetType().Name;
        }
    }
    // Usage
    var some = new SomeClass<int>();
    var name = some.GetName();
