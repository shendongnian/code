    public static class BaseFactory
    {
        public static Base Create(bool condition)
        {
            if (condition)
            {
                return Derived1.Create(1, "TEST");
            }
            else
            {
                return Derived2.Create(1, DateTime.Now);
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
    public sealed class Derived1: Base
    {
        private Derived1(int value, string text): base(value)
        {
        }
        internal static Derived1 Create(int value, string text)
        {
            return new Derived1(value, text);
        }
    }
    public sealed class Derived2: Base
    {
        private Derived2(int value, DateTime time): base(value)
        {
        }
        internal static Derived2 Create(int value, DateTime time)
        {
            return new Derived2(value, time);
        }
    }
