    public class OrderManager : IEnumerable<Order>,ICollection<Order>
-
    [Serializable]
    public class OrderManager : IEnumerable<Order>,ICollection<Order>
    {
        public OrderManager()
        { }
        private List<Order> orders = new List<Order>();
        public Order this[int i]
        {
            set { AddOrder(value); }
            get { return orders[i]; }
        }
        public void AddOrder(Order order)
        {
            orders.Add(order);
        }
        public IEnumerator<Order> GetEnumerator()
        {
            return orders.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return orders.GetEnumerator();
        }
        public void Add(Order item)
        {
            AddOrder(item);
        }
        public void Clear()
        {
            orders.Clear();
        }
        public bool Contains(Order item)
        {
            return orders.Contains(item);
        }
        public void CopyTo(Order[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public int Count
        {
            get { return orders.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(Order item)
        {
            return orders.Remove(item);
        }
    }
