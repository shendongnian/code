    [ServiceContract]
    interface ISomeService
    {
        [OperationContract]
        Collection<AccountSummary> ListAccountsForUser(
            User user /*This information could be out of band in a claim*/);
    }
    [DataContract]
    class AccountSummary
    {
         [DataMember]
         public string AccountNumber {get;set;}
         [DataMember]
         public string AccountType {get;set;}
         //Other account summary information
    }
