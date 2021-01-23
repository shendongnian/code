    using System; 
    enum AccountState
    {
      New,
      Active,
      UnderAudit,
      Frozen,
      Closed
    };
    struct Account
    {
        public AccountState State;
        public string Name;
        public string Address;
        public int AccountNumber;
        public int Balance;
        public int Overdraft;
    };
    class Bankprogram
    {
      public static void Main()
      {   
        Account RobsAccount;
        RobsAccount.State = AccountState.Active;
        RobsAccount.Name = "Rob Miles";
        RobsAccount.AccountNumber = 1234;
        RobsAccount.Address = "his home";
        RobsAccount.Balance = 0;
        RobsAccount.Overdraft = -1;
        Console.WriteLine("name is " + RobsAccount.Name);
        Console.WriteLine("balance is : " + RobsAccount.Balance );
        PrintAccount(RobsAccount);
      }
      public void PrintAccount(Account a)
      {
        Console.WriteLine ("Name" + a.Name);
        Console.WriteLine ("Address :" + a.Address);
        Console.WriteLine ("Balance:" + a.Balance);
      }
    }
