    public class Customer : Entity
    {
        public virtual string Name { get; set; }
        public virtual string City { get; set; }
        public virtual IList<Order> Orders { get; set; }
    }
    public class Order : Entity
    {
        public virtual DateTime OrderDate { get; set; }
        public virtual IList<OrderDetail> OrderDetails { get; set; }
        [IgnoreDataMember]
        public virtual Customer Customer { get; set; }
    }
    public class OrderDetail : Entity
    {
        public virtual string ProductName { get; set; }
        public virtual int Amount { get; set; }
        [IgnoreDataMember]
        public virtual Order Order{ get; set; }
    }
