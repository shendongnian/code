    public class CreatePurchaseOrderHandler : ICommandHandler<CreatePurchaseOrder>
    {
        public void Handle(CreatePurchaseOrder command)
        {
            var po = new PurchaseOrder
            {
                Part = ...,
                Supplier = ...,
            };
            unitOfWork.Savechanges();
        }
    }
