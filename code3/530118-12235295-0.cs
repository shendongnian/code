    private void MakeWithdrawal() {
        //Take money from bank account
        //Exceptions abort the operation
    }
    
    public void WithdrawMoney()
    {
        MakeWithdrawal();
        //Exceptions are printed
    }
    
    public void TransferMoney()
    {
        //Take money from one account and only deposit on another account if no exceptions were caught in WithdrawMoney()
        MakeWithdrawal();
        DepositMoney();     
        //Exceptions are printed
    }
