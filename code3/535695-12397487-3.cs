    public interface IQuery<TResult> {}
    public interface IQueryProcessor
    {
        TResult Execute<TResult>(IQuery<TResult> query)
    }
    public class MyQueryObject : IQuery<MyEntity[]>
    {
        public string QueryParam1 { get; set; }
        public int QueryParam2 { get; set; }
    }
    
