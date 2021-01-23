    public interface ITransactionable
    {
        Transaction CreateTransaction();
    }
    public class BussinessService : ITransactionable
    {
        public Transaction CreateTransaction() 
        { 
            return new ServiceCharge();
        }
    }
    public class Product : ITransactionable
    {
        public Transaction CreateTransaction() 
        { 
            return new Sale();
        }
    }
