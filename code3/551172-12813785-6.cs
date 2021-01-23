    public interface IQuery<TResult> : IQuery
    {
        TResult Result { get; }
    }
    public class QueryExecutor
    {
        // ..
        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            Execute((IQuery)query);
            return query.Result;
        }
    }
    public class ActiveUsersQuery : QueryBase, IQuery<List<string>>
    {
        public int InData1 { get; set; }
        public string InData2 { get; set; }
        public List<string> Result { get; private set; }
        public override void Execute()
        {
            //OutData1 = Context.{do something with InData1 and InData};
        }
    }
