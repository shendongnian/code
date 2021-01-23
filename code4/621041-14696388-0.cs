    public class AccountAddress : Address
    {
       [ForeignKey("Account"]] // Or fluent mapping
       public int AccountId {get; set;}
       public virtual Account Account {get; set;}
       [ForeignKey("Address"]] // Or fluent mapping
       public int AddressId {get; set;}
       public virtual Address Address {get; set;}
       public DateTime BeginDate {get; set;}
       public DateTime PurgeDate {get; set;}
       public bool IsPrimary {get; set;}
    }
