    public class UsesTheDataType
    {
        private readonly Func<Foo, TheDataType> _generateData;
        public UsesTheDataType()
        {
            _generateData = GenerateData;
            _generateData = _generateData.Cached();
        }
        public void UseTheDataType(Foo foo)
        {
            var theDataType = _generateData(foo);
            // theDataType is either a new value or cached value
        }
        private TheDataType GenerateData(Foo foo)
        {
            // Only called the first time for each foo
        }
    }
