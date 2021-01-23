    public class myQueryClass
    {
    public string Property1 { get; set; }
    public string Property2 { get; set; }
    }
    
    var context = new MyDbContext();
    context.Database.SqlQuery<myQueryClass>("SELECT Property1 = acolumn, Property2 = acolumn2 FROM myTable WHERE something = somestate");
