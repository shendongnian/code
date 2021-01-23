    public DataSet sMethod(string sql)
    {
       if (string.IsNullOrEmpty(sql))
       {
           sql = "SELECT * FROM table";
       } 
       SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
    
       ...
    }
