    var connectionString = string.Format("Data Source=localhost;User ID={0};Password={1};", userName, password);
    
    DataTable databases = null;
    using (var sqlConnection = new SqlConnection(connectionString))
    {
        sqlConnection.Open();
        databases = sqlConnection.GetSchema("Databases");
        sqlConnection.Close();
    }
    
    if (databases != null)
    {
        foreach (DataRow row in databases.Rows)
        {
            foreach (var item in row.ItemArray)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }
    }
