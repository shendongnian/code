    public struct MyType
    {
        public const int OneValue = 1;
        public const int TwoValue = 2;
        private static readonly MyType one = new MyType(OneValue);
        private static readonly MyType two = new MyType(TwoValue); 
        private readonly value int;
        private MyType(int value)
        {
            this.value = value;
        }
        public static One
        {
            get { return this.one; }
        }
        public static Two
        {
            get { return this.two; }
        }
        public static implicit operator int(MyType source)
        {
            return source.value;
        }
    }
