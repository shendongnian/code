    public class SqlOperation
    {
        public SqlOperation()
        {
            Queries = new List<string>();
        }
    
        public string TableName { get; set; }
        public string ConnectionString { get; set; }
        public List<string> Queries { get; set; }
    }
    
    public static List<DataTable> GetAllData(IEnumerable<SqlOperation> sql)
    {
        var taskArray =
            sql.SelectMany(s =>
                s.Queries
                 .Select(query =>
                    Task.Run(() => //Task.Factory.StartNew for .NET 4.0
                        ExecuteQuery(s.ConnectionString, s.TableName, query))))
                .ToArray();
        
        try
        {
            Task.WaitAll(taskArray);
        }
        catch(AggregateException e)
        {
            MessageBox.Show(e.ToString(), "GetAllData error");
        }
        
        return taskArray.Where(t => !t.IsFaulted).Select(t => t.Result).ToList();
    }
    
    public static DataTable ExecuteQuery(string connectionString, string tableName, string query)
    {
        DataTable dataTable = null;
        
        using (var connection = new SqlConnection(connectionString))
        {
            dataTable = new DataTable();
            dataTable.TableName = tableName;
            using(var command = new SqlCommand(query, connection))
            {
                connection.Open();
    
                using(var adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = command;
                    adapter.Fill(dataTable);
                }
            }
        }
         
         return dataTable;
    }
