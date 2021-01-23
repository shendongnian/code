    public static string[] GetAccount(int AccountId)
    {        
        LinqSqlDataContext contextLoad = new LinqSqlDataContext();
    
        var q = (from p in contextLoad.MyAccounts
                 where p.AccountId == AccountId
                 select new { Name = p.FirstName, Surname = p.Surname }).Single();
    
        return new []{q.Name, q.Surname};
    } 
