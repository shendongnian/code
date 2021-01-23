    public class Account {
       public AccountId Id { get; set; }
       public Person Customer {get; set; }
       public void Credit(Money amount) { ... }
       public void Debit(Money amount) { ... } 
    }
