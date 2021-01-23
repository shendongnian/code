    public IDictionary<int, string> GetExpenseTypes()
    {
        var result = new Dictionary<int, string>();
                
        using (var conn = new SqlConnection(connStr))
        {
            var getExpenses = new SqlCommand(
                "SELECT ID, TITLE FROM EXPENSE_TYPE",
                conn);
                conn.Open();
                using (var reader = command.ExecureReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetInt32(0), reader.GetString(1));
                    }
                }
        }
        return result;
    }
                 
