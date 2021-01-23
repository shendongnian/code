    public List<DataTable> GetAllData()
    {
        var taskBag = new ConcurrentBag<Task>();
    
        try
        {
            foreach(var s in Sql)
            {
                foreach(var task in s.queries.Select(query => Task.Run(() => ExecuteQuery(s.connection, s.tableName, query))))
                {
                     taskBag.Add(task);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "GetAllData error");
        }
    
        Task.WaitAll(taskBag.ToArray());
    
        return taskBag.Select(t => t.Result).ToList();
    }
    
    public DataTable ExecuteQuery(string connectionString, string tableName, string query)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            DataTable dt = new DataTable();
            dt.TableName = tableName;
            using(var command = new SqlCommand(query, connection))
            {
                 connection.Open();
                 using(var adapter = new SqlDataAdapter())
                 {
                    adapter.SelectCommand = command;
                    adapter.Fill(dt);
                 }
            }
            
            return dt;
         }
    }
