    public class BaseClass
    {
        protected readonly int MyProperty;
        
        public BaseClass()
        {
            MyProperty = 10;
        }
    }
    public class DerivedClass : BaseClass
    {
        public DerivedClass()
        {
            MyProperty = 20;
        }
    }
    
