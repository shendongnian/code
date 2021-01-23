    interface ITransactionable
    {
        Transaction CreateTransaction();
    }
    class BusinessService : ITransactionable
    {
        public Transaction CreateTransaction() { return new ServiceCharge( this ); }
    }
    class Product : ITransactionable
    {
        public Transaction CreateTransaction() { return new Sale( this ); }
    }
----------
    private void CreateInstance(ITransactionable element)
    {
       Transaction transaction = element.CreateTransaction();
       ...
    }   
