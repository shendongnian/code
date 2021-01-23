    public class Customer : IAcceptVisitor
    {
        private readonly string _id;
        private readonly List<string> _items = new List<string>();
        public Customer(string id)
        {
            _id = id;
        }
        public void AddItems(string item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if(_items.Contains(item)) throw new InvalidOperationException();
            _items.Add(item);
        }
        public void Accept(ICustomerVisitor visitor)
        {
            if (visitor == null) throw new ArgumentNullException(nameof(visitor));
            visitor.VisitCustomer(_items);
        }
    }
    public interface IAcceptVisitor
    {
        void Accept(ICustomerVisitor visitor);
    }
    public interface ICustomerVisitor
    {
        void VisitCustomer(List<string> items);
    }
    public class PersistanceCustomerItemsVisitor : ICustomerVisitor
    {
        public int Count { get; set; }
        public List<string> Items { get; set; }
        public void VisitCustomer(List<string> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            Count = items.Count;
            Items = items;
        }
    }
