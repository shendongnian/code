    public class PaypalPayment : IPayment
    {
        public void MakePayment(PaypalPaymentInfo orderInfo)
        {
          ...
        }
    
        public void MakeRefund (PaypalPaymentInfo orderInfo)
        {
          ...
        }
    }
