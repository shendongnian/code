    internal static class IInterfaceUsedByBExtender
    {
        internal static void Func2(this IInterfaceUsedByB obj, int value)
        {
        }
    }
    // caller
    someObject.Func2(5);
