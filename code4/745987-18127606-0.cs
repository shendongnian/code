    public abstract class Base
    {
        public abstract Base New();
    }
    public class Derived1 : Base
    {
        public override Base New()
        {
            return new Derived1();
        }
    }
    public class Derived2 : Base
    {
        public override Base New()
        {
            return new Derived2();
        }
    }
