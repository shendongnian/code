    public class QueryResult:List<string>
    {
        public bool HasMoreResults{get;set;}
    }
    
    public QueryResult TestMethod(Int32 parameter)
    {
        QueryResult res;
        //create list, filling, etc.
        //instead of setting the out, set the parameter
        res.HasMoreResults = ....
    }
