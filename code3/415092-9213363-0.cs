    public class PaymentHelper
    {
        private PaymentDetails _paymentDetails;
        public string PaymentDetailsStatus { get { return _paymentDetails.Status; } }
    
        public PaymentHelper()
        {
            _paymentDetails = new PaymentDetails(); 
        }
    
        public void ModifyPaymentDetails(string someString)
        {
            // code to take the arguments and modify this._paymentDetails
        }
    }
