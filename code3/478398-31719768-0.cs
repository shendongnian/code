    public class SqlDataProvider : ISqlDataProvider
    {
        private readonly DbContext _context;
        public SqlDataProvider(DbContext context)
        {
            _context = context;
        }
        public DataTable GetDataTable(string sqlQuery)
        {
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(_context.Database.Connection);
                using (var cmd = factory.CreateCommand())
                {
                    cmd.CommandText = sqlQuery;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = _context.Database.Connection;
                    using (var adapter = factory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        var tb = new DataTable();
                        adapter.Fill(tb);
                        return tb;
                    }
                }
           }
            catch (Exception ex)
            {
                throw new SqlExecutionException(string.Format("Error occurred during SQL query execution {0}", sqlQuery), ex);
            }
        }
