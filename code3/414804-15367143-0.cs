    void Main()
    {
    	var db = new Test1DataContext(Properties.Settings.Default.TestConnectionString);
    	db.UpInsertTest4Result(1,"1");
    	db.UpInsertTest4Result(1,null);
    	db.UpInsertTest4Result(null,"1");
    	db.UpInsertTest4Result(null,null);
    }
    
    public class Test1DataContext : DataContext
    {
       public Test1DataContext(string connStr) : base(connStr) { }
    	
       [Function(Name = "UpInsertTest4")]
       public IEnumerable<UpInsertTest4Result> UpInsertTest4Result(
        [Parameter(Name = "par1", DbType = "Int")] int? par1,
    	[Parameter(Name = "par2", DbType = "VarChar")] string par2)
       {
           var result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), par1,par2);
    
           return (IEnumerable<UpInsertTest4Result>)result.ReturnValue;
       }
    }
