    class ParameterOrderAttribute : Attribute
    {
        public int Order { get; private set; }
        public ParameterOrderAttribute(int order)
        {
            Order = order;
        }
    }
