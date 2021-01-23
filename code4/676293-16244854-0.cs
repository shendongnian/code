    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Not.LazyLoad();
            Table("Product");
            Id(x => x.Id, "Product_id").GeneratedBy.Assigned();
            Map(x => x.Name).Column("Name").Length(10);
            HasMany(x => x.Inventory)
                .Cascade.Delete()
                .KeyColumn("Product_id");
        }
    }
    public class WarehouseMap : ClassMap<Warehouse>
    {
        public WarehouseMap()
        {
            Not.LazyLoad();
            Table("Warehouse");
            Id(x => x.Id, "Warehouse_id").GeneratedBy.Assigned();
            Map(x => x.Name).Column("Name").Length(10);
            HasMany(x => x.Inventory)
                .Cascade.All()
                .KeyColumn("Warehouse_id");
        }
    }
    public class InventoryMap : ClassMap<Inventory>
    {
        public InventoryMap()
        {
            Not.LazyLoad();
            Table("Inventory");
            CompositeId()
              .KeyReference(x => x.Product, "Product_id")
              .KeyReference(x => x.Warehouse, "Warehouse_id");
            Map(x => x.StockInHand);
        }
    }
