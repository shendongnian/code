    public static int Calculate(DateTime startDate, DateTime endDate)
    {
        string sql = @"SELECT SUM(timestamp) 
                       FROM table1 
                       WHERE date BETWEEN @startDate AND @endDate";
        using(var con=new SqlConnection(connectionString))
        using (var cmd = new SqlCommand(sql, con))
        {
            con.Open();
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);
            int sum = (int)cmd.ExecuteScalar();
            return sum;
        }
    }
