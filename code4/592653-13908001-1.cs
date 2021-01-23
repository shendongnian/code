        public class ValidatingReadonlyField
    {
        private readonly UnKnownClass _readonlyField = new UnKnownClass();
    }
    public class UnKnownClass
    {
        private object _someValue;
        public UnKnownClass()
        {
            _someValue = GetMeSomeThing();
        }
        private static object GetMeSomeThing()
        {
            throw new InvalidOperationException("Can you call me at Compile Time!!!");
        }
    }
