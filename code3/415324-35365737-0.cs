    internal class Repository : IRepository {
        private readonly Func<IDbConnection> _connectionFactory;
    
        public Repository(Func<IDbConnection> connectionFactory) 
        {
            _connectionFactory = connectionFactory;
        }
    
        public IWidget Get(string key) {
            using(var conn = _connectionFactory()) 
            {
                return conn.Query<Widget>(
                   "select * from widgets with(nolock) where widgetkey=@WidgetKey", new { WidgetKey=key });
            }
        }
    }
