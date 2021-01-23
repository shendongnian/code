    public class BaseClass
    {
        private int x;
        private int y;
        public BaseClass(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class DerivedClass : BaseClass
    {
        public DerivedClass(int x = 0, int y = 0)
            : base(x, y)
        { }
    }
