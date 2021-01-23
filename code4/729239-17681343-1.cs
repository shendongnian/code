    public class BussinessService :
        ITransactionable<ServiceCharge>
    {
        public T CreateTransaction() 
        { 
            return new ServiceCharge(this);
        }
    }
    public class Product :
        ITransactionable<Sale>
    {
        public T CreateTransaction() 
        { 
            return new Sale(this);
        }
    }
