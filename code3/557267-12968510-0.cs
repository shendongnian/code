    class ThrowHelper
    {
        [DebuggerStepThrough]
        public static void Throw()
        {
            throw new InvalidOperationException();
        }
    }
