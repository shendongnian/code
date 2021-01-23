    public class PurchaseOrderCommand
    {
        public string PartNumber { get; set; }
        public string SupplierName { get; set; }
    }
    interface IPurchaseOrderService
    {
        void CreatePurchaseOrder(PurchaseOrderCommand command);
    }
