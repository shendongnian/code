    [ServiceContract]
    interface ISomeService
    {
        [OperationContract]
        TransferResult Transfer(TransferRequest request);
    }
    [DataContract]
    class TransferRequest
    {
         [DataMember]
         public string FromAccountNumber {get;set;}
         [DataMember]
         public string ToAccountNumber {get;set;}
         [DataMember]
         public Money Amount {get;set;}
    }
    class SomeService : ISomeService
    {
        TransferResult Transfer(TransferRequest request)
        {
            //Check parameters...omitted for clarity
            var from = repository.Load<Account>(request.FromAccountNumber);
            //Assert that the caller is authorised to request transfer on this account
            var to = repository.Load<Account>(request.ToAccountNumber);
            from.Transfer(to, request.Amount);
            //Build an appropriate response (or fault)
        }
    }
