    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Schema("YOURSCHEMA");
            Table("CUSTOMER");
            Id(x => x.Id, "ID").GeneratedBy.Assigned();
            Map(x => x.Name, "NAM");
            Map(x => x.City, "CITY");
            HasMany(x => x.Orders)
                .KeyColumn("CUSTOMER_ID")
                .Not.LazyLoad()
                .Inverse()
                .Cascade.AllDeleteOrphan();
            DynamicUpdate();
        }
    }
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Schema("YOURSCHEMA");
            Table("CUSTOMER_ORDER");
            Id(x => x.Id, "ID").GeneratedBy.Assigned();
            Map(x => x.OrderDate, "ORDER_DATE");
            HasMany(x => x.OrderDetails)
                .KeyColumn("ORDER_ID")
                .Not.LazyLoad()
                .Inverse()
                .Cascade.AllDeleteOrphan();
            References<Customer>(x => x.Customer, "CUSTOMER_ID");
            DynamicUpdate();
        }
    }
    public class OrderDetailMap : ClassMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            Schema("YOURSCHEMA");
            Table("ORDER_DETAIL");
            Id(x => x.Id, "ID").GeneratedBy.Assigned();
            Map(x => x.ProductName, "PRODUCT_NAME");
            Map(x => x.Amount, "AMOUNT");
            References<Order>(x => x.Order, "ORDER_ID");
            DynamicUpdate();
        }
    }
