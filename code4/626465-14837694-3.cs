    public static IEnumerable<AccountTransaction> GetAllTransactions()
    {       
        using (var context = new CostReportEntities())
        {
            return (from t in context.Transactions
                    join acc in context.Accounts 
                         on t.AccountID equals acc.AccountID              
                    select new AccountTransaction {
                         AccountNumber = acc.AccountNumber,
                         LocalAmount = t.LocalAmount
                    }).ToList();
        }
    }
