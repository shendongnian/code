	public interface IPayment
	{
		void MakePayment(PaymentModel paymentInfo);
		void MakeRefund(PaymentModel paymentInfo);
	}
	
	public interface IPayment<T> : IPayment where T : PaymentModel
	{
	    
	}
	
	public class GooglePayment
	    : IPayment<GooglePaymentModel>
	{
	    public void MakePayment(PaymentModel paymentInfo) {
		GooglePaymentModel googlePayment = (GooglePaymentModel)paymentInfo;
		// ...
	    }
	
	    public void MakeRefund(PaymentModel paymentInfo) {
		GooglePaymentModel googlePayment = (GooglePaymentModel)paymentInfo;
		// ...
	    }
	}
