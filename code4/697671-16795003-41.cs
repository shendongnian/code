    public class PurchaseOrderCommandHandler : ICommandHandler<PurchaseOrderCommand>
    {
        public void Handle(PurchaseOrderCommand command)
        {
            var po = new PurchaseOrder
            {
                Part = ...,
                Supplier = ...,
            };
            unitOfWork.Savechanges();
        }
    }
