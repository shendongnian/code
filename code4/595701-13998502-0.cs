    class ConstantValue : IValueProvider
    {
        public override IList<int> getValues()
        {
             return new List<int> { 1 };
        }
    }
