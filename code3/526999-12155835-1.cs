    public class BaseClass
    {
        public BaseClass()
        {
        }
        protected int MyProperty { get { return 10; } }
    }
    public class DerivedClass : BaseClass
    {
        public DerivedClass()
        {
        }
        protected override int MyProperty { get { return 20; } }
    }
    
