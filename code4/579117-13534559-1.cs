    public class AccountBase
    {
       public Id { get;set;}
       public string Name {get;set;}
    }
    public class Account : AccountBase
    {
        public string SomeAdditionalInfo { get;set;}
    }
