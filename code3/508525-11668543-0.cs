    public class MyResult
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public static string GetAccount(int AccountId)
    {        
        LinqSqlDataContext contextLoad = new LinqSqlDataContext();
    
        var q = (from p in contextLoad.MyAccounts
                 where p.AccountId == AccountId
                 select new MyResult{ Name = p.FirstName, Surname = p.Surname }).Single();
    
        return q;
    } 
