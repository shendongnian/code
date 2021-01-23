    public class MyResults
    {
       public int ID{get;set;}
       public string DomainUrl {get;set;}
    }
    ...
    
    var stores = db.Database.SqlQuery<MyResults>(SQL, parameters).ToList();
