    //INITIALLY this field was non-static 
    //public string ConnectionString = "Data Source=ServerName;Initial Catalog=DBname;User Id=user_id;Password=password";
    //Make this field static
    public static string ConnectionString = "Data Source=ServerName;Initial Catalog=DBname;User Id=user_id;Password=password";
    static SqlConnection sqlConnection = new SqlConnection(ConnectionString);
