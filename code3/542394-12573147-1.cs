    public void ExecuteWithDataReader(string sql, Action<DataReader> stuffToDo) {
        using (SqlConnection connection = new SqlConnection(connectionString)) {
            using (SqlCommand command = new SqlCommand(sql, connection)) {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader()) {
                    try {
                        while (reader.Read()) {
                            stuffToDo(reader);
                        }
                    }
                    finally {
                        reader.Close();
                    }
                }
            }
        }
    }
    
    
    private static void ReadOrderData(string connectionString) {
        string sql = "SELECT OrderID, CustomerID FROM dbo.Orders;";
    
        ExecuteWithDataReader(sql, r => Console.WriteLine(String.Format("{0}, {1}", r[0], r[1])));
    }
