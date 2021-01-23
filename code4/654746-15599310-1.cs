    public class Order
    {
        public Guid OrderId { get; set; }
        public virtual ICollection<OrderMenuItem> Items { get; set; }
    }
