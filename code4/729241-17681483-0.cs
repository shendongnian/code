    interface Transactionable
    {
        Transaction CreateTransaction();
    }
    class BusinessService : Transactionable
    {
        Transaction CreateTransaction() { return new ServiceCharge( this ); }
    }
    class Product : Transactionable
    {
        Transaction CreateTransaction() { return new Sale( this ); }
    }
----------
    private void CreateInstance(Transactionable element)
    {
       Transaction transaction = element.CreateTransaction();
       ...
    }   
