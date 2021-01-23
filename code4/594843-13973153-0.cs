    internal static class NativeCalls
    {
        [DllImport ...]
        private static extern int SomeFunctionCall(...);
        public static int SomeFunction(...)
        {
            return SomeFunctionCall(...);
        }
    }
