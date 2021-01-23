    public string GetExpenseType(int id)
    {
                
        using (var conn = new SqlConnection(connStr))
        {
            var getExpenseType = new SqlCommand(
                "SELECT TITLE FROM EXPENSE_TYPE WHERE ID = @p0",
                conn);
            getExpenseType.Parameters.Add(id);
            conn.Open();
            return (string)getExpenseType.ExecuteScalar();
        }
    }
