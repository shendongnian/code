    internal static class SomeObjectExtender
    {
        internal static void Func2<T>(this T obj, int value) where T : class
        {
        }
    }
    // caller
    someObject.Func2(5);
