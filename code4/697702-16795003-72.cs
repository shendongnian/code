    public class CreatePurchaseOrderHandler : ICommandHandler<CreatePurchaseOrder>
    {
        private readonly IUnitOfWork uow;
        public CreatePurchaseOrderHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void Handle(CreatePurchaseOrder command)
        {
            var order = new PurchaseOrder
            {
                Part = this.uow.Parts.Get(p => p.Number == partNumber),
                Supplier = this.uow.Suppliers.Get(p => p.Name == supplierName),
                // Other properties omitted for brevity...
            };
            this.uow.PurchaseOrders.Add(order);
        }
    }
