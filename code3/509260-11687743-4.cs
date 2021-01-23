    public class Product
    {
        [Mapping(ColumnName = "product_id")]
        public int ProductId { get; private set; }
        [Mapping(ColumnName = "supplier_id")]
        public int SupplierId { get; private set; }
    
        [Mapping(ColumnName = "name")]
        public string Name { get; private set; }
        [Mapping(ColumnName = "price")]
        public decimal Price { get; private set; }
        [Mapping(ColumnName = "total_stock")]
        public int Stock { get; private set; }
        [Mapping(ColumnName = "pending_stock")]
        public int PendingStock { get; private set; }
    }
