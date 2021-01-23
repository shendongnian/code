    public class BaseClass
    {
        public void Method1()
        {
            string a = "Base method";
        }
    }
    
    public class DerivedClass : BaseClass
    {
        public new void Method1()
        {
            string a = "Derived Method";
        }
    }
    
    public class TestApp
    {
        public static void main()
        {
            DerivedClass derivedObj = new DerivedClass();
            BaseClass obj2 = (BaseClass)derivedObj; // cast to base class
            obj2.Method1();  // invokes Baseclass method
        }
    }
