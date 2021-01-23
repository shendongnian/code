    public class PurchaseOrderCommandHandler : ICommandHandler<PurchaseOrderCommand>
    {
        private IUnitOfWork uow;
        public PurchaseOrderCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void Handle(PurchaseOrderCommand command)
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
