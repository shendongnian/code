    public class Product
    {
        public virtual Bytes Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
.
    public ProductMapping()
    {
        Table("tblProduct");
        Id(p => p.Id).Column("prdProductGuid").CustomType<BytesUserType>();
        Map(p => p.Name).Column("prdName");
        Map(p => p.Description).Column("prdDescription");
    }
