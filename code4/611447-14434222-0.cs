    INSERT INTO existProducts (name,date,price,amount) VALUES (@name, @date, @price, @amount)
    public static void  DoQuery(string fileName, string name, DateTime date, float price, float amount)
    {
    
        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();
        SqlCommand com = new SqlCommand(sql, conn);
        com.Paramaters.AddWithValue("name", name);
        com.Parameters.AddWithValue("date", date);
        ...
        ...
        com.ExecuteNonQuery();
        com.Dispose();
        conn.Close();
    
    }
