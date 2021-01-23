    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            this.HasOptional(x => x.Quotation)
                .WithOptionalPrincipal()
                .Map(x => x.MapKey("OrderId"));
        }
    }
     
    public class QuotationMap : EntityTypeConfiguration<Quotation>
    {
        public QuotationMap()
        {
            this.HasOptional(x => x.Order)
                .WithOptionalPrincipal()
                .Map(x => x.MapKey("QuotationId"));
        }
    }
