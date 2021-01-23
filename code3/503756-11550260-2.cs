    public class DTO {public A a{get;set;} public IObjectSet<B> allBs {get;set;} }
    
    var list = (from a in db.As 
                select new DTO
                {
                    a = a,
                }).ToList();
    foreach(var a in list)
    {
        a.allBs = db.Bs;
    }
