        public class PaymentProxy : IPayPal
        {
            private readonly IPayPal original;
            public PaymentProxy(IPayPal original)
            {
                this.original = original;
            }
            public void SaleTransaction()
            {
                original.SaleTransaction();
            }
            public void VoidTransaction()
            {
                original.VoidTransaction();
            }
        }
