    public class BaseClass
    {
        public string MyClassName()
        {
            return this.GetType().Name;
        }
    }
    
    public class DerivedClass : BaseClass
    {
    }
    ...
    BaseClass a = new BaseClass();
    BaseClass b = new DerivedClass();
    Console.WriteLine("{0}", a.MyClassName()); // -> BaseClass
    Console.WriteLine("{0}", b.MyClassName()); // -> DerivedClass
