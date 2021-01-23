    public class Order
    {
        private OrderItems _items;
        public OrderItems items
        {
            get { return _items; }
            set
            {
                _items = value
                _items.order = this
            }
        }
    }
