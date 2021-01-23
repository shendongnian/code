    public class BaseClass
    {
        public BaseClass(string someValue)
        {
            Console.WriteLine(someValue);
        }
    }
    public class MyClass : BaseClass
    {
        private MyClass(string someValue)
            : base(someValue)
        {
        }
        public static MyClass GetNewInstance(string someValue, bool overrideValue = false)
        {
            if (overrideValue)
            {
                someValue = "42";
            }
            return new MyClass(someValue);
        }
    }
