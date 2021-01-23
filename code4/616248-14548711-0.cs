    Class Client
    {
    
        BankAccount acc;
    
        public Client(BankAccount p_acc)
        {
          acc=p_acc;
        }
    
        public void addMoneyToBankAccount(decimal amount)
        {         
            acc.AddMoney(amount);
        }
    
        public decimal CheckBalance()
        {
            return acc.CheckAccountBalance();
        }
    
    }
