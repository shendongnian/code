    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class OrderAttribute : Attribute
    {
        private readonly int order_;
        public OrderAttribute([CallerLineNumber]int order = 0)
        {
            order_ = order;
        }
        public int Order { get { return order_; } }
    }
    public class Test
    {
        //This sets order_ field to current line number
        [Order]
        public int Property2 { get; set; }
        //This sets order_ field to current line number
        [Order]
        public int Property1 { get; set; }
    }
