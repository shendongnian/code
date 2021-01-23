    private static string CONNECTION_NAME = "\\conection.udl";
     private static SqlConnection CreateSqlConnection(OleDbConnection udlInfo)
            {
                try
                {   
                    string CONNECTION_STRING = $"Database={udlInfo.Database};Server={udlInfo.DataSource};Integrated Security=True;connect timeout = 30";
                    var connection = new SqlConnection(CONNECTION_STRING);
                    connection.Open();
                    return connection;
                } catch
                {
                     Console.WriteLine($"{CONNECTION_NAME} Not found");
    
                    return null;
                }
                
            }
    public static SqlConnection GetSqlConnection()
            {
                var udlInfo = new OleDbConnection($"File Name={Application.StartupPath}{CONNECTION_NAME}");
    
                return CreateSqlConnection(udlInfo);
            }
