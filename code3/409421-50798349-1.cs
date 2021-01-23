      [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RLPAttribute : Attribute
    {
        private readonly int order_;
        public RLPAttribute([CallerLineNumber]int order = 0)
        {
            order_ = order;
        }
        public int Order { get { return order_; } }
    }
