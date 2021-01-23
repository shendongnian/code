    public static class BaseFactory
    {
        public static Base Create(bool condition)
        {
            if (condition)
            {
                return new Derived1Creator(1, "TEST");
            }
            else
            {
                return new Derived2Creator(1, DateTime.Now);
            }
        }
        private sealed class Derived1Creator: Derived1
        {
            public Derived1Creator(int value, string text): base(value, text)
            {
            }
        }
        private sealed class Derived2Creator: Derived2
        {
            public Derived2Creator(int value, DateTime time): base(value, time)
            {
            }
        }
    }
    public class Base
    {
        protected Base(int value)
        {
        }
        protected static Base Create(int value)
        {
            return new Base(value);
        }
    }
    public class Derived1: Base
    {
        protected Derived1(int value, string text): base(value)
        {
        }
        protected static Derived1 Create(int value, string text)
        {
            return new Derived1(value, text);
        }
    }
    public class Derived2: Base
    {
        protected Derived2(int value, DateTime time): base(value)
        {
        }
        protected static Derived2 Create(int value, DateTime time)
        {
            return new Derived2(value, time);
        }
    }
