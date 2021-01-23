    public class Context
    {
        // context contains system specific behaviour (connection, session, etc..)
    }
    public interface IQuery
    {
        void SetContext(Context context); 
        void Execute();
    }
    public abstract class QueryBase : IQuery
    {
        private Context _context;
        protected Context Context { get { return _context; } }
        void IQuery.SetContext(Context context)
        {
            _context = context;
        }
        public abstract void Execute();
    }
    public class QueryExecutor
    {
        public void Execute(IQuery query)
        {
            query.SetContext({set system context});
            query.Execute();
        }
    }
