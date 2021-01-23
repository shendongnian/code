    public static string GetAccount(int AccountId, out String FirstName, out String Surname)
    {        
        LinqSqlDataContext contextLoad = new LinqSqlDataContext();
        var q = (from p in contextLoad.MyAccounts
                 where p.AccountId == AccountId
                 select new { Name = p.FirstName, Surname = p.Surname }).Single();
        // Set FirstName and Surname string values.
    } 
