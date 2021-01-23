    public class BaseClass
    {
        private int x;
        private int y;
        public BaseClass()
            : this(0, 0)
        { }
        public BaseClass(int x)
            : this(x, 0)
        { }
        public BaseClass(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class DerivedClass : BaseClass
    {
        public DerivedClass()
            : base()
        { }
        public DerivedClass(int x)
            : base(x)
        { }
        public DerivedClass(int x, int y)
            : base(x, y)
        { }
    }
