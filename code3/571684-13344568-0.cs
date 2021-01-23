    public abstract class Custom
    {
        public static Custom Create(int value)
        { return new CustomImpl<int>(value); }
        public static Custom Create(byte value)
        { return new CustomImpl<byte>(value); }
        public static Custom Create(string value)
        { return new CustomImpl<string>(value); }
        private class CustomImpl<T> : Custom
        {
            public CustomImpl(T val) { /*...*/ }
        }
    }
