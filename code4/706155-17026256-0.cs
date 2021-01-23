    public class ResultObject
    {
        public string ProductName { get; set; }
        public decimal MinProductPrice { get; set; }
        public decimal MaxProductPrice { get; set; }
    }
    //Within your Control or somewhere common
    public IList<TResult> ExecuteSql<TResult>(string sql)
    {
        var results = ((IObjectContextAdapter)DbContext).ObjectContext.ExecuteStoreQuery<TResult>(sql);
        return results;
    }
    //Then, when you need the results, call the ExecuteSql method:
    var productInfo = ExecuteSql<ResultObject>(mySql);
