    public class Order
    {
        ...
        private static Dictionary<int, Order> _orders = new Dictionary<int, Order>();
        public static Order Get(int id)
        {
            return this._order[id];
        }
        private static object _idLocker = new object();
        private static int _nextId = 0;
        public readonly int Id;
        public Order()
        {
            // Just to make sure that the identifiers are unique,
            // even if you have threads messing around.
            lock (_idLocker)
            {
                this.Id = _nextId;
                _nextId++;
            }
            _orders.Add(this.Id, this);
        }
        public Order(int id)
        {
            this.Id = id;
            _orders.Add(this.Id, this);
        }
    }
