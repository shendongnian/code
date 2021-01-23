    public class Account{
      
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public int Age { get; set; }
    
        public Decimal Balance { get; set; }
    
        public Decimal DepositMoney(Decimal amount)
        {
            Balance+=amount;
            return Balance;
        }
        public Decimal WithdrawMoney(Decimal amount)
        {
            Decimal moneyAfterWithdrawal = Balance-amount;
            
            if(moneyAfterWithdrawal >= 0)
            {
               Balance = moneyAfterWithdrawal;
               return Balance;
            }
            throw new Exception(String.Format("Withdrawing {0} would leave you overdrawn!", amount.ToString());
        }
    }
