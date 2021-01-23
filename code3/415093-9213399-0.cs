    public class PaymentHelper
    {
        private PaymentDetails _paymentDetails;
        public IPaymentDetails MyPaymentDetails{ get { return _paymentDetails; } }
    
        public PaymentHelper()
        {
            _paymentDetails = new PaymentDetails(); 
        }
    
        public void ModifyPaymentDetails(string someString)
        {
            // code to take the arguments and modify this._paymentDetails
        }
    }
    interface IPaymentDetails
    {
       int Status { get; }
    }
