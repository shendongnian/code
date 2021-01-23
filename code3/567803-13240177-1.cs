    /// Abstracts over different ways of making payments
    interface IPaymentMaker 
    {
        void MakePayment(string payType, long orderNo);
        // MakeRefund etc.
    }
    /// Refactor code common to all payment types here, and handle the association 
    /// between payment and payment model.
    class PaymentMakerBase<TPaymentModel> : IPaymentMaker 
        where TPaymentModel : IPaymentModel 
    {
        void MakePayment(string payType, long orderNo) 
        {
            NewPayment().MakePayment(NewPaymentModel(payType, orderNo));
        }
        abstract IPayment<TPaymentModel> NewPayment();
        abstract TPaymentModel NewPaymentModel(string payType, long orderNo);
    }
    /// Handle only the differences between payment types that can't be put inside their
    /// implementations
    class PaypalPaymentMaker : PaymentMakerBase<PaypalPayment> 
    {
        IPayment<PaypalPayment> NewPayment() { ... }
        PaypalPayment NewPaymentModel(...) { ... }
    }
    static class PaymentMakerFactory 
    {
        /// The only "not type safe" part, handles parsing the payType string and 
        /// resolving it to the correct `PaymentMaker`
        public IPaymentMaker GetPaymentMaker(string payType) 
        {
            if (Regex.IsMatch(payType, ...)) 
            {
                // return appropriate payment maker for the payType
            }
            else if (...) 
            {
                // ...
            }
        }
    }
