    public static IEnumerable<Transaction> GetAllTransactions()
    {       
        using (var context = new CostReportEntities())
        {
            return (from t in context.Transactions
                    join acc in context.Accounts 
                         on t.AccountID equals acc.AccountID              
                    select t).ToList();
        }
    }
