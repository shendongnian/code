    namespace MyNamespace.Models
    {
        public partial class MyEntities
        {
            
            IQueryable<InventoryItem> InStockInventoryItems()
            {
                return this.InventoryItems.Where(m => m.Quantity > 0);
            }
        }
    }
