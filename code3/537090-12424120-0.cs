    public static DataContext getConnection()
        {
            String SqlOptions = "Put your connection string here";
            
            return new SqlConnection(SqlOptions);
            
        }
