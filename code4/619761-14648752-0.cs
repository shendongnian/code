    public class CustAccount
    {
        public string Account { get; set; }        
        public string AccountType { get; set; }
        public CustSTIOrder(Account ord)
        {
            Account = ord.Account;
            AccountType = ord.AccountType;
        }
    }
