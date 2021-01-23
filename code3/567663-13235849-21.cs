	public interface IPayment
	{
		
	}
	
	public interface IPayment<T> : IPayment where T : PaymentModel
	{
		void MakePayment(T paymentInfo);
		void MakeRefund(T paymentInfo);
	}
