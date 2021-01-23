    public interface IPayment
    {
    
    }
    
    public interface IPayment<T> : IPayment where T : PaymentModel
    {
    
    }
