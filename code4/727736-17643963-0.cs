    public class Order
    {
        public int OrderID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public override bool Equals(object obj)
        {
            Order o2 = obj as Order;
            if (o2 == null) return false;
            return OrderID == o2.OrderID;
        }
        public override int GetHashCode()
        {
            return OrderID;
        }
        public override string ToString()
        {
            return Description;
        }
    }
